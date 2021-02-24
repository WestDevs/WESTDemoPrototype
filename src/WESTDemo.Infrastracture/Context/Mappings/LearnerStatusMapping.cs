using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WESTDemo.Domain.Models;

namespace WESTDemo.Infrastracture.Context.Mappings
{
    public class LearnerStatusMapping : IEntityTypeConfiguration<LearnerStatus>
    {
        public void Configure(EntityTypeBuilder<LearnerStatus> builder)
        {            
            builder.HasKey(b => new { b.LearnerId, b.CourseId });

            builder.ToTable("LearnerStatus");
        }
    }
}