using System.Data.Entity;
using ToursProject.Context.Models;

namespace ToursProject.Context
{
    public class ToursContext : DbContext
    {
        public ToursContext() : base("DefaultConnection")
        {
            
        }
        
        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelComment> HotelComments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ReceivingPoint> ReceivingPoints { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<TypeTour> TypeTours { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
