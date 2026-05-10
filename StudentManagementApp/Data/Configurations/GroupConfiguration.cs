// GroupConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManagementApp.Models;

namespace StudentManagementApp.Data.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable("Groups");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasIndex(x => x.Name)
                   .IsUnique();

            builder.HasMany(x => x.Students)
                   .WithOne(x => x.Group)
                   .HasForeignKey(x => x.GroupId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}