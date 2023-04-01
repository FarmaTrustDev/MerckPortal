using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Hangfire;
using Merck.DTOS;
using Merck.Helpers;
using Merck.Interfaces.Repositories;
using Merck.Models;
using Merck.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
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


        public async Task<string> ReadBlobFileAsync(string blobName)
        {
            try
            {
                // Create a BlobServiceClient object using the connection string
                BlobServiceClient blobServiceClient = new BlobServiceClient(_connectionString);

                // Get a reference to the container
                BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(_containerName);

                // Get a reference to the blob
                BlobClient blobClient = containerClient.GetBlobClient(blobName);

                // Download the blob's contents to a memory stream
                MemoryStream memoryStream = new MemoryStream();
                await blobClient.DownloadToAsync(memoryStream);

                // Convert the memory stream to a string
                string contents = System.Text.Encoding.UTF8.GetString(memoryStream.ToArray());



                // Return the contents of the file
                return contents;
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
                string contents = await ReadBlobFileAsync(blobName);

                FileLog FileDto = new FileLog();
                FileDto.Name = blobName;
                FileDto.Hash = Utility.GetMd5Hash(contents);
                FileDto.Value = contents;
                FileDto.Name = blobName;

                string HashedFileName = Utility.GetHashFileName(blobName); ;
                string content2 = await ReadBlobFileAsync(HashedFileName);

                FileDto.HashFileName = Utility.GetHashFileName(HashedFileName); ;
                FileDto.MerckHash = content2.ToLower();

                FileDto.Tempered = FileDto.Hash != FileDto.MerckHash;

                await InsertIntoDB(FileDto);
                return blobName;
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
