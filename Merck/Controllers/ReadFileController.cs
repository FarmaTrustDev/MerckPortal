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

        public readonly BlobStorageService _blobStorageService;
        public ReadFileController(BlobStorageService blobStorageService)
        {
            _blobStorageService = blobStorageService;
        }
        // GET: api/<ReadFileController>
        [HttpGet]
        public string Get()
        {
            try
            {
                _blobStorageService.GenerateHash("non_hashed");
                return "";
            }
            catch (Exception ex)
            {

                throw ex;
            }

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
