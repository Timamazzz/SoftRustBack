using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftRustBack.Models;

namespace SoftRustBack.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TopicsController : ControllerBase
    {
        //private readonly ApplicationContext _context;

/*        public TopicsController(ApplicationContext context)
        {
            _context = context;
        }*/

        // GET: /Topics
        [HttpGet]
        public ActionResult<IEnumerable<Topic>> Get()
        {
            using (ApplicationContext db = new ApplicationContext()) 
            {
                if (db.Topics == null)
                {
                    return NotFound();
                }
                return db.Topics.ToList();
            }
        }
    }
}
