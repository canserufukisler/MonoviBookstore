using Entities.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using monovi.bookstore.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace monovi.bookstore.dal
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserAccountConfiguration());
        }

        public DbSet<UserAccount> UserAccounts { get; set; }

        public DbSet<Product> Products { get; set; }
    }
}
