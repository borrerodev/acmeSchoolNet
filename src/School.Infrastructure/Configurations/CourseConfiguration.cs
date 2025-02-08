using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Domain.Entities.Course;

namespace School.Infrastructure.Configurations;
internal sealed class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.ToTable("Course");
        builder.HasKey(x => x.Id);        
        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
       
         // Configure the one-to-many relationship
        builder.HasMany(c => c.Students)
               .WithOne(s => s.Course)
               .HasForeignKey(s => s.CourseId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}