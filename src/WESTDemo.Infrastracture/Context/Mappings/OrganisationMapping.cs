using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WESTDemo.Domain.Models;

namespace src.WESTDemo.Infrastracture.Context.Mappings
{
    public class OrganisationMapping : IEntityTypeConfiguration<Organisation>
    {
        public void Configure(EntityTypeBuilder<Organisation> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.ToTable("Organisation");
        }
    }
}