using AcademyTask.Domain.Entities.LikedProduct;
using AcademyTask.Domain.Entities.Product;
using AcademyTask.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademyTask.Infrastructure.Persistence.Configurations;

public class LikedProductConfiguration : IEntityTypeConfiguration<LikedProduct>
{
    public void Configure(EntityTypeBuilder<LikedProduct> builder)
    {
        builder.ToTable("LikedProducts");
        
        builder.HasKey(x => new { x.UserId, x.ProductId });
        builder.HasOne(likedProduct => likedProduct.User).WithMany(user => user.LikedProducts)
            .HasForeignKey(x => x.UserId);
        builder.HasOne(likedProduct => likedProduct.Product).WithMany(product => product.LikedByUsers)
            .HasForeignKey(x => x.ProductId);
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.UpdatedAt).IsRequired();
    }
}