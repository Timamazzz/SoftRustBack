using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftRustBack.Application;
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
        /// <returns></returns>
        [HttpPost("add")]
        public ActionResult<int> Add([FromForm] DTO.Topic topic)
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
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpGet("getall")]
        public ActionResult<List<DTO.Topic>> GetAll()
        {

            return _service.GetAll();
            //throw new Exception("Me exception");
        }

        /// <summary>
        /// Получить тему по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<DTO.Topic> GetById(int id)
        {
            DTO.Topic? topic = _service.GetById(id);

            if (topic == null)
                return NotFound();

            return topic;
        }

        /// <summary>
        /// Обновить тему по id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="topic"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public IActionResult Update(int id, [FromForm] DTO.Topic topic)
        {
            string response = _service.Update(id, topic);
            if (response != "Ok")
                return BadRequest(response);
            else
                return Ok();

        }

        /// <summary>
        /// Удалить тему по id
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
