﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetCorePractice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DotnetCorePractice.Controllers
{
    [Route ("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public IOptionsSnapshot<AppSettings> Settings { get; }

        public ValuesController (IOptionsSnapshot<AppSettings> settings) {
            Settings = settings;
        }

        [HttpGet]
        [Route ("test1")]
        public IActionResult GetTest1 ()
        {
            HttpContext.Session.SetString ("key", "The Doctor");
            return Ok (this.Settings);
        }

        [HttpGet]
        [Route ("test2")]
        public IActionResult GetTest2 ()
        {
            return Ok ("||" + HttpContext.Session.GetString ("key"));
        }

        [HttpGet]
        [Route ("test3")]
        public IActionResult GetTest3 ()
        {
            return Ok ();
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get ()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet ("{id}")]
        public ActionResult<string> Get (int id)
        {
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