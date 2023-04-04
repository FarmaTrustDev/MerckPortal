using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Hangfire;
using Merck.DTOS;
using Merck.Helpers;
using Merck.Interfaces.Repositories;
using Merck.Models;
using Merck.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Merck.Services
{
    public class BlobStorageService
    {
        private readonly string _connectionString = "DefaultEndpointsProtocol=https;AccountName=chdgwdatadev;BlobEndpoint=https://chdgwdatadev.blob.core.windows.net/;QueueEndpoint=https://chdgwdatadev.queue.core.windows.net/;FileEndpoint=https://chdgwdatadev.file.core.windows.net/;TableEndpoint=https://chdgwdatadev.table.core.windows.net/;SharedAccessSignature=sv=2020-08-04&si=farmatrustaccesspolicy&sr=c&sig=G9iM1991Pvbh%2FAgnz7cKHROqf2iRYKrftcpVT%2BSdAiU%3D";
        private readonly string _containerName = "blockchainpoc";
        private readonly IFileLogRepository _fileLogRepository;
        public BlobStorageService(IFileLogRepository fileLogRepository)
        {
            _fileLogRepository = fileLogRepository;
        }

        public IEnumerable<string> ListFilesInFolder(string folderName)
        {
            BlobServiceClient blobServiceClient = new BlobServiceClient(_connectionString);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(_containerName);

            // List all blobs in the folder
            foreach (BlobItem blobItem in containerClient.GetBlobs(prefix: folderName))
            {
                yield return blobItem.Name;

                break;
            }
        }


        public async Task<FileResponseDTO> ReadBlobFileAsync(string blobName)
        {
            try
            {
                FileResponseDTO fileResponseDTO = new FileResponseDTO();
                // Create a BlobServiceClient object using the connection string
                BlobServiceClient blobServiceClient = new BlobServiceClient(_connectionString);

                // Get a reference to the container
                BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(_containerName);

                // Get a reference to the blob
                BlobClient blobClient = containerClient.GetBlobClient(blobName);
                
                BlobProperties blobProperties = blobClient.GetProperties();
                
                long? maxTime=await _fileLogRepository.GetMaxTimestamp();
                if (maxTime==null || blobProperties.CreatedOn.Ticks > maxTime)
                {
                    // Download the blob's contents to a memory stream
                    MemoryStream memoryStream = new MemoryStream();
                    await blobClient.DownloadToAsync(memoryStream);

                    // Convert the memory stream to a string
                    string contents = System.Text.Encoding.UTF8.GetString(memoryStream.ToArray());

                    fileResponseDTO.Contents = contents;
                    fileResponseDTO.CreatedOn = blobProperties.CreatedOn.Ticks;
                }
                // Return the contents of the file
                return fileResponseDTO;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private async Task<string> InsertIntoDB(FileLog FileDto)
        {
            try
            {

                await _fileLogRepository.Create(FileDto);
                return "";
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<string> ReadFileOprationo(string blobName)
        {

            try
            {
                FileResponseDTO contents = await ReadBlobFileAsync(blobName);
                if (contents.Contents != null)
                {
                    var httpContext = new HttpClient();
                    FileLog FileDto = new FileLog();
                    FileDto.Name = blobName;
                    FileDto.Hash = Utility.GetMd5Hash(contents.Contents);
                    FileDto.Value = contents.Contents;
                    FileDto.Name = blobName;
                    FileDto.CreatedOn = contents.CreatedOn;
                    string HashedFileName = Utility.GetHashFileName(blobName);
                    FileResponseDTO content2 = await ReadBlobFileAsync(HashedFileName);
                    string deviceName = GetDeviceName(HashedFileName);
                    FileDto.DeviceName = deviceName;
                    FileDto.HashFileName = Utility.GetHashFileName(HashedFileName); ;
                    FileDto.MerckHash = content2.Contents.ToLower();

                    FileDto.Tempered = FileDto.Hash != FileDto.MerckHash;

                    await InsertIntoDB(FileDto);
                    var content = new StringContent($"{{\"productInfo\":\"{FileDto.MerckHash}\"}}", Encoding.UTF8, "application/json");

                    string url = AppConstants.GetURLByDeviceName(deviceName);
                    var response = await httpContext.PostAsync(url, content);

                    /*HttpResponseMessage response = null;
                    if (deviceName == AppConstants.Device1)
                    {
                        response = await httpContext.PostAsync("https://secret-hollows-96938.herokuapp.com/setProductInfoSetter", content);
                    }
                    if (deviceName == AppConstants.Device2)
                    {
                        response = await httpContext.PostAsync("https://secret-hollows-96938.herokuapp.com/setProductInfoSetter", content);
                    }*/

                    if (response.IsSuccessStatusCode)
                    {
                        // Request was successful
                        var responseContent = await response.Content.ReadAsStringAsync();
                        var jsonResponse = JObject.Parse(responseContent);
                        var transactionId = jsonResponse["transactionHash"].ToString();
                        FileLog fileLog = _fileLogRepository.GetByFileName(FileDto.Name);
                        fileLog.BlockChainTransactionId = transactionId;
                        await _fileLogRepository.Update(fileLog);
                    }
                    return blobName;
                }
                return null;
            }
            catch (Exception exx)
            {

                throw exx;
            }
        }
        public void GenerateHash(string blobName)
        {
            foreach (string fileName in ListFilesInFolder("non_hashed"))
            {

                BackgroundJob.Enqueue(() => ReadFileOprationo(fileName));
                break;
                //ReadBlobFileAsync(fileName);
                //Console.WriteLine(fileName);

                //break;
            }

        }
        public string GetDeviceName(string blobName)
        {
            var pathArray = blobName.Split("/");
            var deviceName = pathArray[1].Split("_")[0];
            return deviceName;
        }
        // sub ko queu kardena haii file name k sath 
        // file agai  
        // json lia
        // json hash kia 
        // hash file uthai
        // compare kia
        //db mai dum kardia 

        // file_name | is_tempared |


    }
}
