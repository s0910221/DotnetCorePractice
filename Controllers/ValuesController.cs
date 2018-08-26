using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetCorePractice.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotnetCorePractice.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase {
        public IAppSettings A1 { get; }
        public IAppSettingsScoped A2 { get; }
        public IAppSettingsSingleton A3 { get; }
        public ValuesController (IAppSettings a1, IAppSettingsScoped a2, IAppSettingsSingleton a3) {
            A1 = a1;
            A2 = a2;
            A3 = a3;
        }

        [HttpGet]
        [Route("test1")]
        public IActionResult GetTest1 () {
            return Ok (A1.Name);
        }

        [HttpGet]
        [Route("test2")]
        public IActionResult GetTest2 () {
            return Ok (A2.Name);
        }

        [HttpGet]
        [Route("test3")]
        public IActionResult GetTest3 () {
            return Ok (A3.Name);
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get () {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet ("{id}")]
        public ActionResult<string> Get (int id) {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post ([FromBody] string value) { }

        // PUT api/values/5
        [HttpPut ("{id}")]
        public void Put (int id, [FromBody] string value) { }

        // DELETE api/values/5
        [HttpDelete ("{id}")]
        public void Delete (int id) { }
    }
}