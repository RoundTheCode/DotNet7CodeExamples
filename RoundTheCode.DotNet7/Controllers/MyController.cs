using Microsoft.AspNetCore.Mvc;
using RoundTheCode.DotNet7.Services;

namespace RoundTheCode.DotNet7.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MyController : ControllerBase
    {
        [HttpGet]
        public ActionResult MyTime(IMyService myService)
        {
            return Ok(new { Time = myService.MyTime });
        }
    }
}
