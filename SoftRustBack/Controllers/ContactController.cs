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
    public class ContactController : ControllerBase
    {
        private readonly ContactService _service;
        public ContactController(ContactService service)
        {
            _service = service;
        }

        /// <summary>
        /// Добавить новый контакт
        /// </summary>
        /// <param name="contact"></param>
        [HttpPost("add")]
        public ActionResult<int> Add([FromBody] DTO.Contact contact)
        {
            int id = _service.Create(contact);
            if (id >= 0)
                return id;
            else
                return BadRequest();
        }

        /// <summary>
        /// Получить все контакты
        /// </summary>
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

        /// <summary>
        /// Получить новый контакт по id
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("{id}")]
        public ActionResult<DTO.Contact> GetById(int id)
        {
            DTO.Contact? contact = _service.GetById(id);

            if (contact == null)
                return NotFound();

            return contact;
        }

        /// <summary>
        /// Обновить контакт
        /// </summary>
        /// <param name="id"></param>
        /// <param name="contact"></param>
        [HttpPut]
        public IActionResult Update([FromBody] DTO.Contact contact)
        {
            string response = _service.Update(contact);
            if (response != "Ok")
                return BadRequest(response);
            else
                return Ok();

        }

        /// <summary>
        /// Удалить контакт по id
        /// </summary>
        /// <param name="id"></param>
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
