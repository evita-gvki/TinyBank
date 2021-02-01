using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.Design;

namespace TinyBank.Core
{
    public class CrmDbContext : DbContext
    {
        const string connectionString =

           "Server=localhost;Database=crmdb2;User Id=sa;Password=admin!@#123;";

        public CrmDbContext()

        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>()
                .ToTable("Customer");

            modelBuilder.Entity<Customer>()
                 .HasIndex(c => c.VatNumber)
                 .IsUnique();

            modelBuilder.Entity<Account>()
                .ToTable("Account");

            modelBuilder.Entity<Account>()
                 .HasIndex(a => a.AccountId)
                 .IsUnique();

            modelBuilder.Entity<Transaction>()
                .ToTable("Transactions");

                    }
    }
}

