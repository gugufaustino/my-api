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
    public class AppStatusController 
    {

        const string Permissao = "STATUS";

        private readonly ILogger<CadastroController> _logger;
        private readonly IHostEnvironment _hostingEnvironment;
        private readonly IHostApplicationLifetime _hostApplicationLifetime;

        public AppStatusController(ILogger<CadastroController> logger,
                                    IHostEnvironment hostingEnvironment,
                                    IHostApplicationLifetime hostApplicationLifetime)
        {
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
            _hostApplicationLifetime = hostApplicationLifetime;
        }

        [HttpGet] 
        public ActionResult<string> Get()
        {
            var STATUS = $"APP - ON as {_hostingEnvironment.EnvironmentName}";

            return STATUS;            
        }
        [HttpPost]
        public void Post(string tolken)
        {
            if (tolken == "stop-st")
                _hostApplicationLifetime.StopApplication();
        }
    }
}
