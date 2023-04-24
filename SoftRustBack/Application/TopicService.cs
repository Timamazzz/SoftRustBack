using SoftRustBack.DTO.Repositories;
using SoftRustBack.Models;

namespace SoftRustBack.Application
{
    /// <summary>
    /// Бизнес логика тем сообщений
    /// </summary>
    public class TopicService
    {
        private readonly TopicRepository _repository;

        /// <summary>
        /// Подключение рептозитория
        /// </summary>
        /// <param name="repository"></param>
        public TopicService(TopicRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Создание темы
        /// </summary>
        /// <param name="topicDTO"></param>
        public int Create(DTO.Topic topicDTO)
        { 
            return _repository.Create(topicDTO);
        }

        /// <summary>
        /// Получение всех тем
        /// </summary>
        public List<DTO.Topic>? GetAll()
        {
            List<Topic> topics = _repository.GetAll();

            if (topics == null)
                return null;

            List<DTO.Topic> topicsDTO = new List<DTO.Topic>();
            foreach (Topic topic in topics)
            {
                topicsDTO.Add(new DTO.Topic { Id = topic.Id, Name = topic.Name });
            }
            return topicsDTO;
        }

        /// <summary>
        /// Получение темы по id
        /// </summary>
        /// <param name="id"></param>
        public DTO.Topic? GetById(int id)
        {
            Topic? topic = _repository.GetById(id);

            if (topic == null)
                return null;

            return new DTO.Topic { Id = topic.Id, Name = topic.Name };
        }

        /// <summary>
        /// Обновление темы по id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="topicDTO"></param>
        public string Update(int id, DTO.Topic topicDTO)
        {
           return _repository.Update(id, topicDTO);
        }

        /// <summary>
        /// Удаление темы по id
        /// </summary>
        /// <param name="id"></param>
        public string Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}
