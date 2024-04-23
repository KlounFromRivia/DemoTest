using System.Collections.Generic;

namespace DemoTest.Context.Models
{
    public class Comment
    {
        /// <summary>
        /// Сущность комментариев
        /// </summary>
        public int Id { get; set; }
        public string Message { get; set; }
        public int WorkerId { get; set; }
        public User Worker { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}