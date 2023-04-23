using Microsoft.AspNetCore.Mvc;
using SoftRustBack.DTO.Repositories;
using SoftRustBack.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SoftRustBack.Application
{
    /// <summary>
    /// Юизнес логика сообщений
    /// </summary>
    public class MessageService
    {
        private readonly ContactService _contactsService;
        private readonly TopicService _topicsService;
        private readonly MessageRepository _repository;

        /// <summary>
        /// Подключение сервисов и репозитория
        /// </summary>
        /// <param name="context"></param>
        /// <param name="contactsService"></param>
        /// <param name="topicsService"></param>
        /// <param name="repository"></param>
        public MessageService(ApplicationContext context, ContactService contactsService, TopicService topicsService, MessageRepository repository)
        {
            _contactsService = contactsService;
            _topicsService = topicsService;
            _repository = repository;
        }

        /// <summary>
        /// Добавление сообщения
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public int Create(DTO.Message message)
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

        /// <summary>
        /// Полуение всех сообщений
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Получение сообщения по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DTO.Message? GetById(int id) 
        {
            Message? message = _repository.GetById(id);

            if (message == null)
                return null;

            return new DTO.Message { ContactId = message.ContactId, ContactName = message.Contact?.Name, Email = message.Contact?.Email, Phone = message.Contact?.Phone, Text = message.Text, TopicId = message.TopicId, TopicName = message.Topic?.Name };
        }

        /// <summary>
        /// Обновлеие сообщения по id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="messageDTO"></param>
        /// <returns></returns>
        public string Update(int id, DTO.Message messageDTO)
        {
            return _repository.Update(id, messageDTO);
        }

        /// <summary>
        /// Удаление сообщения по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}
