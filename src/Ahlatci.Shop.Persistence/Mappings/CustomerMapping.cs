using Ahlatci.Shop.Domain.Common;
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
	public class CustomerMapping : AuditableEntityMapping<Customer>
	{
		public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Customer> builder)
		{
			builder.Property(x=>x.CityId)
				.HasColumnName("CITY_ID")
				.HasColumnOrder(3);

			builder.Property(x=>x.IdentityNumber)
				.HasColumnName("IDENDITY_NUMBER")
				.HasColumnType("nchar(11)")
				.HasColumnOrder(4);

			builder.Property(x => x.Name)
				.HasColumnName("NAME")
				.IsRequired()
				.HasColumnType("nvarchar(30)")
				.HasColumnOrder(5);

			builder.Property(x=>x.SurName)
				.HasColumnName("SURNAME")
				.IsRequired()
				.HasColumnType("nvarchar(30)")
				.HasColumnOrder(6);

			builder.Property(x => x.Email)
				.HasColumnName("EMAIL")
				.IsRequired()
				.HasColumnType("nvarchar(150)")
				.HasColumnOrder(7);

			builder.Property(x => x.Phone)
				.HasColumnName("PHONE")
				.IsRequired()
				.HasColumnType("nvarchar(13)")
				.HasColumnOrder(8);

			builder.Property(x => x.Birtdate)
				.HasColumnName("BIRTDATE")
				.IsRequired()
				.HasColumnOrder(9);

			builder.Property(x => x.Gender)
				.HasColumnName("GENDER")
				.IsRequired()
				.HasColumnOrder(10);
			
			// birden çoğa ilişki için tablo böyle düzenlenir.s
			builder.HasOne(x => x.City)
				.WithMany(x => x.Customers)
				.HasForeignKey(x => x.CityId)
				.HasConstraintName("CUSTOMER_CITY_ACCOUNT_ID");

			builder.ToTable("CUSTOMERS");


		}
	}
}
