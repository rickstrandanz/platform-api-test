using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

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
        public JsonResult Get()
        {
            var version = new Version() { 
                            ApplicationVersion = "0",
                            LastCommitSHA = "...",
                            Description = "Platform api test - Version" };

            var json = JsonConvert.SerializeObject(version);

            return new JsonResult(json);
        }
    }
}
