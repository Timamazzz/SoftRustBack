using SoftRustBack.Controllers.Services.Validators;
using SoftRustBack.DTO.Repositories;
using SoftRustBack.Models;

namespace SoftRustBack.Application
{
    /// <summary>
    /// Бизнес логика контактов
    /// </summary>
    public class ContactService
    {
        private readonly ContactRepository _repository;

        /// <summary>
        /// Подключение репозитория
        /// </summary>
        /// <param name="repository"></param>
        public ContactService(ContactRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Создание нового сообщения
        /// </summary>
        /// <param name="contactDTO"></param>
        public int Create(DTO.Contact contactDTO) 
        {
            if (IsValid(contactDTO))
            {
                int contact_id = GetByDTO(contactDTO);

                if (contact_id < 0)
                    return _repository.Create(contactDTO);
                else
                {
                    Update(contactDTO);
                    return contact_id;
                }
                
            }
            else
                return -1;
        }

        /// <summary>
        /// Получение всех сообщений
        /// </summary>
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

        /// <summary>
        /// Получение сообщения по id
        /// </summary>
        /// <param name="id"></param>
        public DTO.Contact? GetById(int id)
        {
            Contact? contact = _repository.GetById(id);

            if (contact == null)
                return null;

            return new DTO.Contact { Id = contact.Id, Name = contact.Name, Email = contact.Email, Phone = contact.Phone };
        }

        /// <summary>
        /// Получение id сообщения по полученному DTO с фронта
        /// </summary>
        /// <param name="contactDTO"></param>
        public int GetByDTO(DTO.Contact contactDTO)
        {
            Contact? contact = _repository.GetByDTO(contactDTO);
            if (contact == null)
                return -1;
            else
                return contact.Id;
        }

        /// <summary>
        /// Обновление сообшения по id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="contactDTO"></param>
        public string Update(DTO.Contact contactDTO)
        {
            if (IsValid(contactDTO))
                return _repository.Update(contactDTO);
            else
                return "Invalid Data";
        }

        /// <summary>
        /// Удаление сообщения по id
        /// </summary>
        /// <param name="id"></param>
        public string Delete(int id)
        {
            return _repository.Delete(id);
        }

        /// <summary>
        /// Валидация контакта
        /// </summary>
        /// <param name="contact"></param>
        public bool IsValid(DTO.Contact contact)
        {
            if (NameValidator.isName(contact.Name) && EmailValidator.isEmail(contact.Email) && PhoneValidator.IsPhoneNumber(contact.Phone))
                return true;
            else
                return false;
        }
    }
}
