using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnowledgeHubPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace konwledgeHubPortal.Data
{
    public class KHPDbContext : DbContext
    {
        // map db
        public KHPDbContext()
        {
            
        }
        public KHPDbContext(DbContextOptions<KHPDbContext> options):base(options)
        {
            // configuring through mvc / web api
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) //if connection string is not specified through constructor then use this
            {
                optionsBuilder.UseSqlServer("Data Source = (localdb)\\mssqllocaldb; Initial Catalog = KHPDb2024; Integrated Security = True;" +
                    " Encrypt = True");
            }
        }
        // map tables
        public DbSet<Catagory> Catagories { get; set; }
        public DbSet<Article> Articles { get; set; }
    }
}
