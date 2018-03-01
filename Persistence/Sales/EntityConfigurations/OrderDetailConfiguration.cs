using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Models;

namespace Trips.Persistence.Sales.EntityConfigurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("OrderDetail", "dbo").HasKey(t => t.Id);
            builder.HasOne(od => od.Order).WithMany(o => o.OrderDetails).HasForeignKey(od => od.OrderId).HasConstraintName("FK_OrderDetail_Order").OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(od => od.Product).WithMany(p => p.OrderDetails).HasForeignKey(od => od.ProductId).HasConstraintName("FK_OrderDetail_Product").OnDelete(DeleteBehavior.Restrict);
        }
    }
}