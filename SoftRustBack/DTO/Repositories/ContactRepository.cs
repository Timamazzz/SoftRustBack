using SoftRustBack.Models;
using Microsoft.EntityFrameworkCore;

namespace SoftRustBack.DTO.Repositories
{
    public class ContactRepository : IRepository<DTO.Contact, Models.Contact>
    {
        private readonly ApplicationContext _context;
        public ContactRepository(ApplicationContext context)
        {
            _context = context;
        }

        public int Create(Contact contactDTO)
        {
            Models.Contact? contact = new Models.Contact { Name = contactDTO.Name, Email = contactDTO.Email, Phone = contactDTO.Phone };

            _context.Contacts.Add(contact);
            _context.SaveChanges();

            return contact.Id;
        }

        public List<Models.Contact> GetAll()
        {
            return _context.Contacts.ToList();
        }

        public Models.Contact? GetById(int id)
        {
            Models.Contact? contact = _context.Contacts.SingleOrDefault(c => c.Id == id);

            if (contact == null)
                return null;

            return contact;
        }

        public string Update(int id, Contact contactDTO)
        {
            Models.Contact? contact = GetById(id);
            if (contact == null)
                return "Not found";

            contact.Name = contactDTO.Name;
            contact.Email = contactDTO.Email;
            contact.Phone = contactDTO.Phone;
            _context.Contacts.Update(contact);
            _context.SaveChanges();

            return "Ok";
        }

        public string Delete(int id)
        {
            if (_context.Contacts == null)
            {
                return $"Contacts is empty";
            }
            Models.Contact? contact = _context.Contacts.Include(c => c.Messages).SingleOrDefault(c => c.Id == id);
            if (contact == null)
            {
                return $"Not found contact with id:{id}";
            }

            _context.Contacts.Remove(contact);
            _context.SaveChanges();

            return "Ok";
        }
        public Models.Contact? GetByDTO(Contact contactDTO)
        {
            Models.Contact? contact = _context.Contacts.SingleOrDefault(c => c.Email == contactDTO.Email && c.Phone == contactDTO.Phone);
            if (contact == null)
                return null;
            return contact;

        }

    }
}
