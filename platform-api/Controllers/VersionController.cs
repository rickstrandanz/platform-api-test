using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Reflection;

namespace platform_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Produces("application/json")]
    public class VersionController : ControllerBase
    {
        private readonly ILogger<VersionController> _logger;

        public VersionController(ILogger<VersionController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ContentResult Get()
        {
            var assemblyInfo = Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;


            var version = new Version() { 
                            ApplicationVersion = assemblyInfo.Split('-')[0],
                            LastCommitSHA = assemblyInfo.Split('-')[1],
                            Description = "Platform api test - Version" };

            var json = JsonSerializer.Serialize(version);

            return  Content(json,"application/json;", Encoding.UTF8);
        }
    }
}
