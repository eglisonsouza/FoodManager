using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantsFoods.Domain.Entities;

namespace RestaurantsFoods.Infra.Persistence.Mappings
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasColumnName("Name");

            builder.Property(c => c.ImageUrl)
                .IsRequired()
                .HasColumnType("varchar(5000)")
                .HasColumnName("ImageUrl");

            builder.Property(c => c.CreatedAt)
                .IsRequired()
                .HasColumnType("datetime")
                .HasColumnName("CreatedAt");

            builder.Property(c => c.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("UpdatedAt");

            builder.Property(c => c.IsDeleted)
                .IsRequired()
                .HasColumnType("bit")
                .HasColumnName("IsDeleted");
        }
    }
}
