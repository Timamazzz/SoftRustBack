using Microsoft.AspNetCore.Mvc;
using SoftRustBack.DTO.Repositories;
using SoftRustBack.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SoftRustBack.Application
{
    public class MessageService
    {
        private readonly ContactsService _contactsService;
        private readonly TopicsService _topicsService;
        private readonly MessageRepository _repository;


        public MessageService(ApplicationContext context, ContactsService contactsService, TopicsService topicsService, MessageRepository repository)
        {
            _contactsService = contactsService;
            _topicsService = topicsService;
            _repository = repository;
        }
        public int Add(DTO.Message message)
        {
            DTO.Contact contactDTO = new DTO.Contact { Name = message.ContactName, Email = message.Email, Phone = message.Phone };

            int contactId =_contactsService.Create(contactDTO);
            if (contactId < 0)
            {
                return -1;
            }

            int? topicId = message.TopicId;

            if (topicId == null)
                return -1;

            if (topicId == -1)
            {
                topicId = _topicsService.Create(new DTO.Topic { Name = message.TopicName });   
            }
            if (topicId < 0)
                return -1;

            return _repository.Create(new DTO.Message { ContactId = contactId, Text = message.Text, TopicId = topicId });
        }
        public List<DTO.Message>? GetAll() 
        {
            List<Message> messages = _repository.GetAll();
            if (messages == null)
                return null;

            List<DTO.Message> messagesDTO = new List<DTO.Message>();
            foreach (Message message in messages)
            {
                messagesDTO.Add(new DTO.Message
                {
                    ContactId = message.ContactId,
                    ContactName = message.Contact?.Name,
                    Email = message.Contact?.Email,
                    Phone = message.Contact?.Phone,
                    Text = message.Text,
                    TopicId = message.TopicId,
                    TopicName = message.Topic?.Name,

                });
            }
            return messagesDTO;
        }
        public DTO.Message? GetById(int id) 
        {
            Message? message = _repository.GetById(id);

            if (message == null)
                return null;

            return new DTO.Message { ContactId = message.ContactId, ContactName = message.Contact?.Name, Email = message.Contact?.Email, Phone = message.Contact?.Phone, Text = message.Text, TopicId = message.TopicId, TopicName = message.Topic?.Name };
        }
        public string Update(int id, DTO.Message messageDTO)
        {
            return _repository.Update(id, messageDTO);
        }
        public string Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}
