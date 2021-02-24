using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WESTDemo.Domain.Models;

namespace WESTDemo.Infrastracture.Context.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.FirstName)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(b => b.LastName)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.ToTable("Users");
        }
    }
}
