﻿using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SoftRustBack.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        public int? ContactId { get; set; }
        public int? TopicId { get; set; }
        public Contact? Contact { get; set; }
        public Topic? Topic { get; set; }
    }
}