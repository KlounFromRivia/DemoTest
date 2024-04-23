using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTest.Context.Models
{
    /// <summary>
    /// Сущность пользователя
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string FIO { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public ICollection<Order> OrderClient { get; set; }
        public ICollection<Order> OrderWorker { get; set; }
    }
}
