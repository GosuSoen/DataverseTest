using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataverseTest.Models
{
    public class DataverseDbContext : DbContext
    {
        public DataverseDbContext(DbContextOptions<DataverseDbContext> options)
            : base(options)
        { }

        public DbSet<Contact> Contact { get; set; }
        public DbSet<ContactPhone> ContactPhones { get; set; }

        //In case we want to add or change some database model options
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
