using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToursProject.Context.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Patronymic { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        public ICollection<HotelComment> HotelComments { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
