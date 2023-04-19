using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftRustBack.Controllers.Services.Validators;
using SoftRustBack.Models;
using SoftRustBack.DTO;

namespace SoftRustBack.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        [HttpPost("isValid")]
        public IActionResult isValid([FromBody] DTO.Contact contact)
        {
            string response = "";
            if (NameValidator.isName(contact.Name) && EmailValidator.isEmail(contact.Email) && PhoneValidator.IsPhoneNumber(contact.Phone))
                response = "Everything is fine";
            else
                response = "Invalid email or phone number";

            return Ok(response);
        }
    }
}
