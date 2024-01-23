using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToursProject.Context.Models
{
    public class Tour
    {
        public int Id { get; set; }

        [Required]
        public int TicketCount { get; set; }

        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[] ImagePreview { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public bool IsActual { get; set; }

        public ICollection<Hotel> Hotels { get; set; }
        public ICollection<TypeTour> Types { get; set; }
        public ICollection<Order> Orders { get; set; }

        public Tour()
        {
            Hotels = new List<Hotel>();
            Orders = new List<Order>();
            Types = new List<TypeTour>();
        }

    }
}
