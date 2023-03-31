using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System.Collections.Generic;

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
