using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Domain.Payment;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantManagement.Infrastructure.Payments
{
    public class PaymentDbContext : DbContext
    {
        DbSet<Payment> Payments { get; set; }


        public PaymentDbContext(DbContextOptions<PaymentDbContext> dbContextOptions) 
            : base(dbContextOptions)
        {

        }

        public PaymentDbContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Payment>()
                .ToTable("Payments");

            modelBuilder
                .Entity<Payment>()
                .HasKey(x => x.PaymentId);

            modelBuilder
                .Entity<Payment>()
                .Property<string>("paymentToken")
                .HasColumnName("PaymentToken");

            modelBuilder.Entity<Payment>()
                .Property<int>("orderId")
                .HasColumnName("OrderId")
                .IsRequired();

            modelBuilder
                .Entity<Payment>()
                .HasAlternateKey("orderId");

            modelBuilder
                .Entity<Payment>()
                .Property<PaymentType>("paymentType")
                .HasColumnName("PaymentType"); ;
          
        }
    }
}
