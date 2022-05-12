using GuestManagement.Domain.Guests;
using GuestManagement.Domain.Guests.Visits;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace GuestManagement.Infrastructure.Guests
{
    public class GuestDbContext : DbContext
    {
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Visit> Visits { get; set; }


        #region ctrs
        public GuestDbContext(DbContextOptions<GuestDbContext> options)
         : base(options)
        {

        }



        ///!Migration Purposes

        //     public GuestDbContext()
        // {
        // }



        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Guest>()
                .ToTable("Guests");
            modelBuilder
                .Entity<Guest>()
                .HasKey(v => v.GuestId);
            modelBuilder.Entity<Guest>()
                .Property<string>("FirstName")
                .HasColumnName("FirstName");
            modelBuilder.Entity<Guest>()
                .Property<string>("LastName")
                .HasColumnName("LastName");
            modelBuilder.Entity<Guest>()
                .Property<string>("Email")
                .HasColumnName("Email")
                .IsRequired();
            modelBuilder.Entity<Guest>()
                .Property<string>("PhoneNumber")
                .HasColumnName("PhoneNumber")
                .IsRequired();
            modelBuilder
                .Entity<Guest>()
                .HasMany(x => x.Visits);


            modelBuilder
                .Entity<Visit>()
                .HasKey(v => v.VisitId);
            modelBuilder
                .Entity<Visit>()
                .Property<DateTime>("TimeStart")
                .HasColumnName("TimeStart");
            modelBuilder
                .Entity<Visit>()
                .Property<DateTime>("TimeEnd")
                .HasColumnName("TimeEnd");
            modelBuilder.Entity<Visit>()
                .Property<Decimal>("Paycheck")
                .HasColumnName("Paycheck");

            modelBuilder.Entity<Visit>()
                .Property<bool>("IsActive")
                .HasColumnName("IsActive");

        }

        ///Migration purposes

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {                        
        //     IConfigurationRoot configuration = new ConfigurationBuilder()
        //    .SetBasePath($"{Directory.GetCurrentDirectory()}")
        //    .AddJsonFile("appsettings.Development.json")
        //    .Build();
           
        //     var connectionString = configuration["ConnectionStrings:GuestDbConnectionString"];               
        //     optionsBuilder.UseMySql(connectionString);
        // }


    }
}
