using Ahlatci.Shop.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahlatci.Shop.Persistence.Mappings
{
	public class OrderDetailMapping : AuditableEntityMapping<OrderDetail>
	{
		public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<OrderDetail> builder)
		{
			builder.Property(x => x.OrderId)
				.HasColumnName("ORDER_ID")
				.HasColumnOrder(2);

			builder.Property(x => x.ProductId)
				.HasColumnName("PRODUCT_ID")
				.HasColumnOrder(3);

			builder.Property(x => x.Quantity)
				.HasColumnName("QUANTİTY")
				.HasColumnOrder(4);

			builder.Property(x => x.TotalPrice)
				.HasColumnName("TOTAL_PRICE")
				.HasColumnOrder(5);

			builder.HasOne(x => x.Order)
				.WithMany(x => x.OrderDetails)
				.HasForeignKey(x => x.OrderId)
				.HasConstraintName("ORDER_DETAIL_ORDER_ORDER_ID");

			builder.HasOne(x => x.Product)
				.WithMany(x => x.OrderDetails)
				.HasForeignKey(x => x.ProductId)
				.HasConstraintName("ORDER_DETAIL_PRODUCT_PRODUCT_ID");

			builder.ToTable("ORDERDETAILS");
		}
	}
}
