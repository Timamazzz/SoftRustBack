using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftRustBack.Controllers.Services.Validators;
using SoftRustBack.Models;
using SoftRustBack.DTO;
using SoftRustBack.Application;

namespace SoftRustBack.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ContactsService _service;
        public ContactsController(ContactsService service)
        {
            _service = service;
        }
        [HttpPost("add")]
        public ActionResult<int> Add([FromForm] DTO.Contact contact)
        {
            int id = _service.Create(contact);
            if (id >= 0)
                return id;
            else
                return BadRequest();
        }
        [HttpGet("getall")]
        public ActionResult<List<DTO.Contact>> GetAll()
        {
            List<DTO.Contact>? contacts = _service.GetAll();
            if (contacts == null)
            {
                return NotFound();
            }
            return contacts;
        }
        [HttpGet("{id}")]
        public ActionResult<DTO.Contact> GetById(int id)
        {
            DTO.Contact? contact = _service.GetById(id);

            if (contact == null)
                return NotFound();

            return contact;
        }
        [HttpPatch("{id}")]
        public IActionResult Update(int id, [FromForm] DTO.Contact contact)
        {
            string response = _service.Update(id, contact);
            if (response != "Ok")
                return BadRequest(response);
            else
                return Ok();

        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            string response = _service.Delete(id);
            if (response == "Ok")
                return Ok();
            else
                return BadRequest(response);
        }

    }
}
