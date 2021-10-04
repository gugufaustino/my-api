using ApiApplication.Extensions;
using ApiApplication.ViewModel;
using AutoMapper;
using Business.Interface;
using Business.Interface.Repository;
using Business.Interface.Services;
using Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ApiApplication.Controllers
{
     
    [Route("api/status")]
    public class AppStatusController : ControllerBase
    {
        private readonly IHostEnvironment _hostingEnvironment;
        private readonly IHostApplicationLifetime _hostApplicationLifetime;

        public AppStatusController(IHostEnvironment hostingEnvironment,
                                   IHostApplicationLifetime hostApplicationLifetime)
        {
            _hostingEnvironment = hostingEnvironment;
            _hostApplicationLifetime = hostApplicationLifetime;
        }

        [HttpGet] 
        public ActionResult<string> Get()
        {
            var STATUS = $"APP - ON as {_hostingEnvironment.EnvironmentName} <br>";
            return STATUS;            
        }

        [HttpPost]
        public ActionResult Post([FromBody] string data)
        {
            if (data == "stop-st")
            {
                _hostApplicationLifetime.StopApplication();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
