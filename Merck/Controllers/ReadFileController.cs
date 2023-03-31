using Hangfire;
using Merck.Services;
using Microsoft.AspNetCore.Mvc;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Merck.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadFileController : ControllerBase
    {
        // GET: api/<ReadFileController>
        [HttpGet]
        public string Get()
        {
            //BlobStorageService blobStorageService = new BlobStorageService("your_connection_string_here", "your_container_name_here");

            //foreach (string fileName in blobStorageService.ListFilesInFolder("your_folder_name_here"))
            //{
            //    Console.WriteLine(fileName);
            //}
            BlobStorageService blobStorageService = new BlobStorageService("DefaultEndpointsProtocol=https;AccountName=chdgwdatadev;BlobEndpoint=https://chdgwdatadev.blob.core.windows.net/;QueueEndpoint=https://chdgwdatadev.queue.core.windows.net/;FileEndpoint=https://chdgwdatadev.file.core.windows.net/;TableEndpoint=https://chdgwdatadev.table.core.windows.net/;SharedAccessSignature=sv=2020-08-04&si=farmatrustaccesspolicy&sr=c&sig=G9iM1991Pvbh%2FAgnz7cKHROqf2iRYKrftcpVT%2BSdAiU%3D", "blockchainpoc");


            foreach (string fileName in blobStorageService.ListFilesInFolder("non_hashed"))
            {
                blobStorageService.ReadBlobFileAsync(fileName);
                Console.WriteLine(fileName);
                break;
            }
            BackgroundJob.Enqueue(() => new JobServices().Execute());
            return "";
        }

        // GET api/<ReadFileController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ReadFileController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ReadFileController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ReadFileController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
