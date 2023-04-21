using Microsoft.AspNetCore.Mvc;
using SoftRustBack.Application;


namespace SoftRustBack.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessagesController : ControllerBase
    {
        private readonly MessageService _service;
        public MessagesController(MessageService service)
        { 
            _service = service;
        }
        [HttpPost("add")]
        public ActionResult<int> Add([FromForm] DTO.Message message)
        {
            int id = _service.Add(message);
            if (id >= 0)
                return id;
            else
                return BadRequest();
        }

        [HttpGet("getall")]
        public ActionResult<IEnumerable<DTO.Message>> GetAll()
        {
            List<DTO.Message>? messages = _service.GetAll();
            if (messages == null)
                return NotFound();

            return messages;
        }

        [HttpGet("{id}")]
        public ActionResult<DTO.Message> GetById(int id)
        {
            DTO.Message? message = _service.GetById(id);

            if (message == null)
                return NotFound();

            return message;
        }

        [HttpPatch("{id}")]
        public IActionResult Update(int id, [FromForm]DTO.Message messageDTO)
        {
            string response = _service.Update(id, messageDTO);
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