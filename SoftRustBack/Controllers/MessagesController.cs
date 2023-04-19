using Microsoft.AspNetCore.Mvc;
using SoftRustBack.Models;
using System.Security.Cryptography;

namespace SoftRustBack.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessagesController : ControllerBase
    {
        [HttpPost("Add")]
        public DTO.Message Add(DTO.Message message)
        {
            Contact? contact;
            Topic? topic;

            using (ApplicationContext db = new ApplicationContext())
            {
                contact = db.Contacts.Where(c=>c.Email==message.Email && c.Phone==message.Phone).SingleOrDefault();

                if (contact == null)
                {
                    contact = new Contact { Name = message.Contact_name, Email = message.Email, Phone = message.Phone };
                    db.Contacts.Add(contact);
                }

                topic = db.Topics.FirstOrDefault(t => t.Name == message.Topic_name);

                if (topic == null)
                {
                    topic = new Topic { Name = message.Topic_name };
                    db.Topics.Add(topic);

                }

                db.Messages.Add(new Message { Contact = contact, Text = message.Text, Topic = topic });

                db.SaveChanges();
            }
            return message;
        }
    }
}