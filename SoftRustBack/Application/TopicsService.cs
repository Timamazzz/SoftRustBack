using SoftRustBack.DTO.Repositories;
using SoftRustBack.Models;

namespace SoftRustBack.Application
{
    public class TopicsService
    {
        private readonly TopicRepository _repository;

        public TopicsService(TopicRepository repository)
        {
            _repository = repository;
        }
        public int Create(DTO.Topic topicDTO)
        { 
            return _repository.Create(topicDTO);
        }
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
        public DTO.Topic? GetById(int id)
        {
            Topic? topic = _repository.GetById(id);

            if (topic == null)
                return null;

            return new DTO.Topic { Id = topic.Id, Name = topic.Name };
        }
        public string Update(int id, DTO.Topic topicDTO)
        {
           return _repository.Update(id, topicDTO);
        }
        public string Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}
