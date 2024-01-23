using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToursProject.Context.Models
{
    public class TypeTour
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Tour> Tours { get; set; }

        public TypeTour()
        {
            Tours = new List<Tour>();
        }
    }
}
