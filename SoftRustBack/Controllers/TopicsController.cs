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
    public class TopicsController : ControllerBase
    {
        private readonly TopicsService _service;
        public TopicsController(TopicsService service)
        {
            _service = service;
        }
        [HttpPost("add")]
        public ActionResult<int> Add([FromForm] DTO.Topic topic)
        {
            int id = _service.Create(topic);
            if (id >= 0)
                return id;
            else
                return BadRequest();
        }
        [HttpGet("getall")]
        public ActionResult<List<DTO.Topic>> GetAll()
        {
            List<DTO.Topic>? topics = _service.GetAll();
            if (topics == null)
            {
                return NotFound();
            }
            return topics;
        }
        [HttpGet("{id}")]
        public ActionResult<DTO.Topic> GetById(int id)
        {
            DTO.Topic? topic = _service.GetById(id);

            if (topic == null)
                return NotFound();

            return topic;
        }
        [HttpPatch("{id}")]
        public IActionResult Update(int id, [FromForm] DTO.Topic topic)
        {
            string response = _service.Update(id, topic);
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
