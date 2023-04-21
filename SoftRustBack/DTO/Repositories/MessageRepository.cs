using SoftRustBack.Models;
using Microsoft.EntityFrameworkCore;


namespace SoftRustBack.DTO.Repositories
{
    public class MessageRepository : IRepository<DTO.Message, Models.Message>
    {
        private readonly ApplicationContext _context;
        public MessageRepository(ApplicationContext context)
        {
            _context = context;
        }
        public int Create(Message messageDTO)
        {
            Models.Message? message = new Models.Message { ContactId = messageDTO.ContactId, Text = messageDTO.Text, TopicId = messageDTO.TopicId };
            if (message == null)
            {
                return -1;
            }
            _context.Messages.Add(message);
            _context.SaveChanges();

            return message.Id;
        }
        public List<Models.Message> GetAll()
        {
            return _context.Messages.Include(m => m.Contact).Include(m => m.Topic).ToList();
        }
        public Models.Message? GetById(int id)
        {
            Models.Message? message = _context.Messages.Include(m => m.Contact).Include(m => m.Topic).SingleOrDefault(m => m.Id == id);

            if (message == null)
                return null;

            return message;
        }
        public string Update(int id, Message messageDTO)
        {
            Models.Message? message = GetById(id);
            if (message == null)
                return "Not found";

            message.TopicId = messageDTO.TopicId;
            message.Text = messageDTO.Text;

            _context.Messages.Update(message);
            _context.SaveChanges();

            return "Ok";
        }
        public string Delete(int id)
        {
            if (_context.Messages == null)
            {
                return $"Messages is empty";
            }
            Models.Message? message = _context.Messages.SingleOrDefault(m => m.Id == id);
            if (message == null)
            {
                return $"Not found message with id:{id}";
            }

            _context.Messages.Remove(message);
            _context.SaveChanges();

            return "Ok";
        }
    }
}
