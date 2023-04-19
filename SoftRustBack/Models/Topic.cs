namespace SoftRustBack.Models
{
    public class Topic
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Message> Messages { get; set; } = new();

    }
}