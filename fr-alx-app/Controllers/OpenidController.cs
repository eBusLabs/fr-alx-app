using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FRAlexaApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenidController : ControllerBase
    {
        // GET: api/Openid
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST: api/Openid
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Openid/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
