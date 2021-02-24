using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WESTDemo.Domain.Models;

namespace WESTDemo.Infrastracture.Context.Mappings
{
    public class LearnerMapping : IEntityTypeConfiguration<Learner>
    {
        public void Configure(EntityTypeBuilder<Learner> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.UserId)
                .IsRequired()
                .HasColumnType("int");

            builder.ToTable("Learner");
        }
    }
}