using System;
using System.IO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Gateway.Infrastructure.Users{

    public class UsersDbContext : IdentityDbContext<User>{

  public UsersDbContext(DbContextOptions<UsersDbContext> options) : base( options)
  {
      
  }

#if MIGRATION
  public UsersDbContext()
  {
      
  }

       protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {                        
            IConfigurationRoot configuration = new ConfigurationBuilder()
           .SetBasePath($"{Directory.GetCurrentDirectory()}")
           .AddJsonFile("appsettings.Development.json")
           .Build();
           
            var connectionString = configuration["ConnectionStrings:GuestDbConnectionString"];               
            optionsBuilder.UseMySql(connectionString);
        }


    
#endif
    }

}