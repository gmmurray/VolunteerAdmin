using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VolunteerAdmin.Models;

namespace VolunteerAdmin.Data
{
    public class AdminContext : DbContext
    {
        public AdminContext(DbContextOptions<AdminContext> options) : base(options)
        {
        }

        public DbSet<Volunteer> Volunteers { get; set; }
        //public DbSet<AvailableTime> AvailableTimes { get; set; }
        //public DbSet<Center> Centers { get; set; }
        //public DbSet<License> Licenses { get; set; }
        //public DbSet<Skill> Skills { get; set; }
        public DbSet<Opportunity> Opportunities { get; set; }
        public DbSet<Assignment> Assignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Volunteer>().ToTable("Volunteer");
            //modelBuilder.Entity<AvailableTime>().ToTable("Available Time");
            //modelBuilder.Entity<Center>().ToTable("Center");
            //modelBuilder.Entity<License>().ToTable("License");
            //modelBuilder.Entity<Skill>().ToTable("Skill");
            modelBuilder.Entity<Opportunity>().ToTable("Opportunity");
            modelBuilder.Entity<Assignment>().ToTable("Assignment");
        }
    }
}
