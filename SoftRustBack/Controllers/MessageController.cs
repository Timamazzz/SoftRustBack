using Microsoft.AspNetCore.Mvc;
using SoftRustBack.Application;


namespace SoftRustBack.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly MessageService _service;
        public MessageController(MessageService service)
        { 
            _service = service;
        }

        /// <summary>
        /// Доавить новое сообшение
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [HttpPost("add")]
        public ActionResult<int> Add([FromForm] DTO.Message message)
        {
            int id = _service.Create(message);
            if (id >= 0)
                return id;
            else
                return BadRequest();
        }

        /// <summary>
        /// Получить все сообщения
        /// </summary>
        /// <returns></returns>
        [HttpGet("getall")]
        public ActionResult<IEnumerable<DTO.Message>> GetAll()
        {
            List<DTO.Message>? messages = _service.GetAll();
            if (messages == null)
                return NotFound();

            return messages;
        }

        /// <summary>
        /// Получить сообщение по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<DTO.Message> GetById(int id)
        {
            DTO.Message? message = _service.GetById(id);

            if (message == null)
                return NotFound();

            return message;
        }

        /// <summary>
        /// Обновить сообщение по id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="messageDTO"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public IActionResult Update(int id, [FromForm]DTO.Message messageDTO)
        {
            string response = _service.Update(id, messageDTO);
            if (response != "Ok")
                return BadRequest(response);
            else
                return Ok();

        }

        /// <summary>
        /// Удалить сообщение по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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