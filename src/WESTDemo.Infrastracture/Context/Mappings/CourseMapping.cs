using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WESTDemo.Domain.Models;

namespace src.WESTDemo.Infrastracture.Context.Mappings
{
    public class CourseMapping : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(b => b.IconPath)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.ToTable("Course");
        }
    }
}