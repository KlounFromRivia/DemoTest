using System.Collections.Generic;

namespace DemoTest.Context.Models
{
    public class Status
    {
        /// <summary>
        /// Сущность статус заказа
        /// </summary>
        public int Id { get; set; }
        public string Description { get; set; }
        public ICollection<Order> Order { get; set; }
    }
}