using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace DemoTest.Context.Models
{
    /// <summary>
    /// Сущность заказа
    /// </summary>
    public class Order
    {
        public int Id { get; set; }
        public DateTime CreateOrder { get; set; }
        [Required]
        public string ModelEquipment { get; set; }
        public int TypeEquipmentId { get; set; }
        public TypeEquipment TypeEquipments { get; set; }
        [Required]
        public string ReasonDefect { get; set; }
        
        public int ClientId { get; set; }
        public User Client { get; set; }
        public int StatusId { get; set; }
        public Status Statuses { get; set; }
        public int? WorkerId { get; set; }
        public User Worker { get; set; }
        public string Zapchasty { get; set; } = string.Empty;
        public ICollection<Comment> OrderComment { get; set; }
    }
}