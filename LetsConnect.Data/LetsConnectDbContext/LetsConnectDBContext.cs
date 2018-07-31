using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using LetsConnect.Models;
using LetsConnect.Entities.Models;
using Microsoft.EntityFrameworkCore;


namespace LetsConnect.DBContext
{
    public class LetsConnectDBContext:DbContext
    {
        public LetsConnectDBContext(DbContextOptions<LetsConnectDBContext> options) : base(options)
        {
            //this.Configuration.LazyLoadingEnabled = false;
        }


        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Experience> Experience { get; set; }
        public DbSet<Technologies> Technologies { get; set; }
        public DbSet<UserTechnologies> UserTechnologies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {         
            modelBuilder.Entity<UserTechnologies>()
                    .HasKey(x => new { x.UserID, x.TechnologyID });

            modelBuilder.Entity<UserTechnologies>()
                .HasOne(x => x.User)
                .WithMany(y => y.UserTechnology)
                .HasForeignKey(x => x.UserID);

            modelBuilder.Entity<UserTechnologies>()
                .HasOne(x => x.Technologies)
                .WithMany(y => y.UserTechnology)
                .HasForeignKey(x => x.TechnologyID);

            base.OnModelCreating(modelBuilder);
        }

    }
}