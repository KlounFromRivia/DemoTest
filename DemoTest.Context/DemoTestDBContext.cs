using DemoTest.Context.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTest.Context
{
    public class DemoTestDBContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<TypeEquipment> TypeEquipments { get; set; }
        public DbSet<Order> Orders { get; set; }
        
        public DemoTestDBContext(): base("ConfDB")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .HasMany(x => x.OrderClient)
                .WithRequired(x => x.Client)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(x => x.OrderWorker)
                .WithOptional(x => x.Worker);
        }
    }
}
