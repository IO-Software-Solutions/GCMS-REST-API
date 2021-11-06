using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rest_Api.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Resident> Residents { get; set; }

        public DbSet<Collector> Collectors { get; set; }

        public DbSet<Garbage> Garbages { get; set; }

        public DbSet<Container> Containers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Collector>().HasAlternateKey(u => u.Phone);

            modelBuilder.Entity<Collector>().HasAlternateKey(u => u.Email);

            modelBuilder.Entity<Resident>().HasAlternateKey(u => u.Phone);

            modelBuilder.Entity<Resident>().HasAlternateKey(u => u.Email);
        }
    }
}
