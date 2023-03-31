using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Merck.Services
{
    public class BlobStorageService
    {
        private readonly string _connectionString;
        private readonly string _containerName;

        public BlobStorageService(string connectionString, string containerName)
        {
            _connectionString = connectionString;
            _containerName = containerName;
        }

        public IEnumerable<string> ListFilesInFolder(string folderName)
        {
            BlobServiceClient blobServiceClient = new BlobServiceClient(_connectionString);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(_containerName);

            // List all blobs in the folder
            foreach (BlobItem blobItem in containerClient.GetBlobs(prefix: folderName))
            {
                yield return blobItem.Name;
            }
        }


        public async Task<string> ReadBlobFileAsync(string blobName)
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
