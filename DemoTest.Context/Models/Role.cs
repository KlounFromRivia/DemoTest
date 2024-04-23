using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DemoTest.Context.Models
{
    public class Role
    {
        /// <summary>
        /// Сущность ролей
        /// </summary>
        public int Id { get; set; }
        [Required]
        public string RoleTitle { get; set; }
        public ICollection<User> User { get; set; }
    }
}