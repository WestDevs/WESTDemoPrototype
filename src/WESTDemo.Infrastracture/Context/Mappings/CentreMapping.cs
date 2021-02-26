using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WESTDemo.Domain.Models;

namespace WESTDemo.Infrastracture.Context.Mappings
{
    public class CentreMapping : IEntityTypeConfiguration<Centre>
    {
        public void Configure(EntityTypeBuilder<Centre> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.ToTable("Centre");
        }
        
    }
}