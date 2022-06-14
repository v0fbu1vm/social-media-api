using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Interfaces;
using SocialMedia.Core.Models.Mail;

namespace SocialMedia.Rest.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TempController : ControllerBase
    {
        [HttpGet]
        public IActionResult HelloWorld() => Ok("Hello World!");
    }
}
