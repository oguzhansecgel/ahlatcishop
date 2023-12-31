﻿using Ahlatci.Shop.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Ahlatci.Shop.Persistence.Mappings
{
	public class ProductMapping : AuditableEntityMapping<Product>
	{
		public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Product> builder)
		{
			builder.Property(x => x.CategoryId)
			   .HasColumnName("CATEGORY_ID")
			   .HasColumnOrder(2);

			builder.Property(x => x.Name)
				.HasColumnName("NAME")
				.HasColumnType("nvarchar(255)")
				.HasColumnOrder(3);

			builder.Property(x => x.Detail)
			   .HasColumnName("DETAIL")
			   .HasColumnType("nvarchar(max)")
			   .HasColumnOrder(4);

			builder.Property(x => x.UnitInStock)
			   .HasColumnName("UNIT_IN_STOCK")
			   .HasColumnOrder(5);

			builder.Property(x => x.UnitPrice)
			   .HasColumnName("UNIT_PRICE")
			   .HasColumnOrder(6);

			builder.HasOne(x => x.Category)
				.WithMany(x => x.Products)
				.HasForeignKey(x => x.CategoryId)
				.HasConstraintName("PRODUCT_CATEGORY_CATEGORY_ID");

			builder.ToTable("PRODUCTS");


		}
	}
}
