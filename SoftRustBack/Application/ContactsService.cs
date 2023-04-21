using Microsoft.AspNetCore.Mvc;
using SoftRustBack.Controllers.Services.Validators;
using SoftRustBack.DTO.Repositories;
using SoftRustBack.Models;

namespace SoftRustBack.Application
{
    public class ContactsService
    {
        private readonly ContactRepository _repository;

        public ContactsService(ContactRepository repository)
        {
            _repository = repository;
        }
        public int Create(DTO.Contact contactDTO) 
        {
            if (IsValid(contactDTO))
            {
                int contact_id = GetByDTO(contactDTO);

                if (contact_id < 0)
                    return _repository.Create(contactDTO);
                else
                {
                    Update(contact_id, contactDTO);
                    return contact_id;
                }
                
            }
            else
                return -1;
        }
        public List<DTO.Contact>? GetAll()
        {
            List<Contact> contacts = _repository.GetAll();

            if (contacts == null)
                return null;

            List<DTO.Contact> contactsDTO = new List<DTO.Contact>();
            foreach (Contact contact in contacts)
            {
                contactsDTO.Add(new DTO.Contact { Id = contact.Id, Name = contact.Name, Email = contact.Email, Phone = contact.Phone });
            }
            return contactsDTO;
        }
        public DTO.Contact? GetById(int id)
        {
            Contact? contact = _repository.GetById(id);

            if (contact == null)
                return null;

            return new DTO.Contact { Id = contact.Id, Name = contact.Name, Email = contact.Email, Phone = contact.Phone };
        }
        public int GetByDTO(DTO.Contact contactDTO)
        {
            Contact? contact = _repository.GetByDTO(contactDTO);
            if (contact == null)
                return -1;
            else
                return contact.Id;
        }
        public string Update(int id, DTO.Contact contactDTO)
        {
            if (IsValid(contactDTO))
                return _repository.Update(id, contactDTO);
            else
                return "Invalid Data";
        }
        public string Delete(int id)
        {
            return _repository.Delete(id);
        }
        public bool IsValid(DTO.Contact contact)
        {
            if (NameValidator.isName(contact.Name) && EmailValidator.isEmail(contact.Email) && PhoneValidator.IsPhoneNumber(contact.Phone))
                return true;
            else
                return false;
        }
    }
}
