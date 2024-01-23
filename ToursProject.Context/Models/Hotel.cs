using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToursProject.Context.Models
{
    public class Hotel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int CountOfStars { get; set; }

        [Required]
        public string CountryCode { get; set; }
        public Country Country { get; set; }
        public string Description { get; set; }

        public ICollection<HotelComment> HotelComments { get; set; }
        public ICollection<Tour> Tours { get; set;}    

        public Hotel()
        {
            Tours = new List<Tour>();
        }
    }
}
