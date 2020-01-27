using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using monovi.bookshop.model;
using System;

namespace Entities.Configuration
{
    public class UserAccountConfiguration : IEntityTypeConfiguration<UserAccount>
    {
        public void Configure(EntityTypeBuilder<UserAccount> builder)
        {
            builder.ToTable("UserAccount");
            builder.HasData
            (
                new UserAccount
                {
                    Id = 1,
                    FullName = "Test User",
                    Email = "Test@test.com",
                    UserName = "testUser"
                }
            );
        }
    }
}
