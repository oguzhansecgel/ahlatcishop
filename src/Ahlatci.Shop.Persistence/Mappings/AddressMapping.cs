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
	public class AddressMapping : BaseEntityMapping<Address>
	{
		public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Address> builder)
		{
			builder.Property(x => x.CityId)
				.HasColumnName("CITY_ID")
				.HasColumnOrder(2);

			builder.Property(x => x.Text)
				.HasColumnName("TEXT")
				.HasColumnType("nvarchar(255)")
				.HasColumnOrder(3);

			builder.HasOne(x => x.City)
				.WithMany(x => x.Address)
				.HasForeignKey(x => x.CityId)
				.HasConstraintName("ADDRESS_CITY_CITY_ID");
		}
	}
}
