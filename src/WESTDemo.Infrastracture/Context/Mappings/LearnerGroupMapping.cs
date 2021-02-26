// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;
// using WESTDemo.Domain.Models;

// namespace src.WESTDemo.Infrastracture.Context.Mappings
// {
//     public class LearnerGroupMapping : IEntityTypeConfiguration<LearnerGroup>
//     {
//         public void Configure(EntityTypeBuilder<LearnerGroup> builder)
//         {
//             builder.HasKey(b => new { b.LearnerId, b.GroupId });

//             builder.ToTable("LearnerGroup");
//         }
//     }
// }