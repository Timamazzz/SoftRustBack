using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftRustBack.Models;

namespace SoftRustBack.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        // POST: /Contact
        [HttpPost("")]
        public IActionResult Post(String Email, String Phone)
        {
            return Ok();
        }
        public IActionResult Post(String Name, String Email, String Phone)
        {
            return Ok();
        }
    }
}
