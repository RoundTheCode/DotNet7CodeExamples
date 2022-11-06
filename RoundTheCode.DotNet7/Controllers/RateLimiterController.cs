using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
//using Microsoft.AspNetCore.RateLimiting;

namespace RoundTheCode.DotNet7.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RateLimiterController : ControllerBase
    {
        [EnableRateLimiting("TestPolicy")]
        [HttpGet]
        public IEnumerable<int> Get()
        {
            return new List<int>
            {
                { 2 },
                { 4 },
                { 6 }
            };
        }
    }
}