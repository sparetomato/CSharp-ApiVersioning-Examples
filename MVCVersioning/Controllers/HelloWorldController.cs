using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MVCVersioning.Controllers
{
    [Route("api/{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("3.0")]
    [ApiVersion("2.0")]
    [ApiVersion("1.0", Deprecated = true)]
    public class HelloWorldController : ControllerBase
    {
        [HttpGet("Hello"), MapToApiVersion("1.0")]
        public string Get() => "Hello world!";

        [HttpGet("Hello"), MapToApiVersion("2.0")]
        public string GetV2() => "Hello world v2.0!";
        
        [HttpGet("Goodbye")]
        public string Get3() => "Goodbye cruel world!";
    }
}
