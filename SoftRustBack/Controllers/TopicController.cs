using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftRustBack.Application;
using SoftRustBack.DTO;
using SoftRustBack.Models;

namespace SoftRustBack.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly TopicService _service;
        public TopicController(TopicService service)
        {
            _service = service;
        }

        /// <summary>
        /// Добавить новую тему сообщения
        /// </summary>
        /// <param name="topic"></param>
        [HttpPost("add")]
        public ActionResult<int> Add([FromBody] DTO.Topic topic)
        {
            int id = _service.Create(topic);
            if (id >= 0)
                return id;
            else
                return BadRequest();
        }

        /// <summary>
        /// Получить все темы сообщений
        /// </summary>
        [HttpGet("getall")]
        public ActionResult<List<DTO.Topic>> GetAll()
        {
            List<DTO.Topic>? topics = _service.GetAll();
            if (topics != null)
                return topics;
            else
                return BadRequest();       
        }

        /// <summary>
        /// Получить тему по id
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("{id}")]
        public ActionResult<DTO.Topic> GetById(int id)
        {
            DTO.Topic? topic = _service.GetById(id);
            if (topic != null)
                return topic;
            else
                return NotFound();
        }

        /// <summary>
        /// Обновить тему
        /// </summary>
        /// <param name="id"></param>
        /// <param name="topic"></param>
        [HttpPut]
        public IActionResult Update([FromBody] DTO.Topic topic)
        {
            string response = _service.Update(topic);
            if (response != "Ok")
                return BadRequest(response);
            else
                return Ok();
        }

        /// <summary>
        /// Удалить тему по id
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
