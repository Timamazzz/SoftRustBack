using Microsoft.AspNetCore.Mvc;
using SoftRustBack.Models;

namespace SoftRustBack.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageFormController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
/*                Contact contact = new Contact { Name = "TestName", Email = "TestEmail@email.com", Phone = "99999999999" };
                db.Contacts.Add(contact);

                Topic topic = new Topic { Name = "Техподдержка" };
                Topic topic2 = new Topic { Name = "Продажи" };
                Topic topic3 = new Topic { Name = "Другое" };
                db.Topics.AddRange(topic, topic2, topic3);

                Message message = new Message { Text = "TestMessageText", Contact = contact, Topic = topic };
                db.Messages.Add(message);

                db.SaveChanges();*/

/*                var messages = db.Messages.ToList();
                for (int i = 0; i < messages.Count; i++) {
                    db.Messages.Remove(messages[i]);
                }
                var topics = db.Topics.ToList();
                for (int i = 0; i < topics.Count; i++)
                {
                    db.Topics.Remove(topics[i]);
                }
                var contacts = db.Contacts.ToList();
                for (int i = 0; i < contacts.Count; i++)
                {
                    db.Contacts.Remove(contacts[i]);
                }
                db.SaveChanges();*/
            }
            return Ok("Database changed");
        }
    }
}