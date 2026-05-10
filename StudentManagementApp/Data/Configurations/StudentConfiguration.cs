// StudentConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManagementApp.Models;

namespace StudentManagementApp.Data.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.FullName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.Age)
                   .IsRequired();

            builder.Property(x => x.Email)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.HasIndex(x => x.Email)
                   .IsUnique();

            builder.Property(x => x.GroupId)
                   .IsRequired();

            builder.HasOne(x => x.Group)
                   .WithMany(x => x.Students)
                   .HasForeignKey(x => x.GroupId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}