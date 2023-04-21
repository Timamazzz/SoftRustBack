using Microsoft.EntityFrameworkCore.Storage;
using NuGet.Protocol;
using SoftRustBack.Models;
using System.Runtime.InteropServices;

namespace SoftRustBack.DTO.Repositories
{
    public class TopicRepository : IRepository<DTO.Topic, Models.Topic>
    {
        private readonly ApplicationContext _context;
        public TopicRepository(ApplicationContext context)
        {
            _context = context;
        }
        public int Create(Topic topicDTO)
        {
            Models.Topic? topic = new Models.Topic { Name = topicDTO.Name };
            if (topic == null)
            {
                return -1;
            }
            _context.Topics.Add(topic);
            _context.SaveChanges();

            return topic.Id;
        }
        public List<Models.Topic> GetAll()
        {
            return _context.Topics.ToList();
        }
        public Models.Topic? GetById(int id)
        {
            Models.Topic? topic = _context.Topics.SingleOrDefault(t => t.Id == id);

            if (topic == null)
                return null;

            return topic;
        }
        public string Update(int id, Topic topicDTO)
        {
            Models.Topic? topic = GetById(id);
            if (topic == null)
                return "Not found";

            topic.Name = topicDTO.Name;
            _context.Topics.Update(topic);
            _context.SaveChanges();

            return "Ok";
        }
        public string Delete(int id)
        {
            if (_context.Topics == null)
            {
                return $"Topics is empty";
            }
            Models.Topic? topic = _context.Topics.SingleOrDefault(t => t.Id == id);
            if (topic == null)
            {
                return $"Not found topic with id:{id}";
            }

            topic.SoftDeleted = true;
            _context.SaveChanges();

            return "Ok";
        }
    }
}
