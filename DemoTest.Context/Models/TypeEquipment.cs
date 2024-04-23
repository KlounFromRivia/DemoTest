using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DemoTest.Context.Models
{
    public class TypeEquipment
    {
        /// <summary>
        /// Сущность тип оборудования
        /// </summary>
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public ICollection<Order> Order { get; set; }
    }
}