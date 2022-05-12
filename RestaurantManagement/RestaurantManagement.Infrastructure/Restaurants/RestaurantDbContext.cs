using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RestaurantManagement.Domain.Restaurants;
using System.IO;

namespace RestaurantManagement.Infrastructure.Restaurants
{
    public class RestaurantDbContext : DbContext
    {

        public static readonly ILoggerFactory loggerFactory
       = LoggerFactory.Create(builder => { builder.AddConsole(); });


        public DbSet<Restaurant> Restaurants { get; set; }

        public DbSet<RestaurantGuest> RestaurantGuests { get; set; }


#if MIGRATION
        public RestaurantDbContext()
        {
        }
#endif

        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) 
            : base(options)
        {
      
        }

   
       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Restaurant>()
                .Property("maxNumberOfGuests")
                .HasColumnName("MaxNumberOfGuests");

            modelBuilder
                .Entity<Restaurant>()
                .HasMany("currentGuests");

            modelBuilder
                .Entity<RestaurantGuest>()
                .HasKey(x => x.RestaurantGuestId);

            modelBuilder
                .Entity<RestaurantGuest>()
                .Property(x => x.RestaurantGuestId)
                .HasColumnName("CurrentGuestId");

            modelBuilder
              .Entity<RestaurantGuest>()
              .Property(x => x.GuestId)
              .HasColumnName("GuestId");


        }
#if MIGRATION
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {                        
            IConfigurationRoot configuration = new ConfigurationBuilder()
           .SetBasePath($"{Directory.GetCurrentDirectory()}")
           .AddJsonFile("appsettings.Development.json")
           .Build();
           
            var connectionString = configuration["ConnectionStrings:GuestDbConnectionString"];               
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
#endif
    }
}

