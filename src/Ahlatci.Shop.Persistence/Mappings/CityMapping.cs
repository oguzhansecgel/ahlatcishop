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
	public class CityMapping : BaseEntityMapping<City>

	{
		public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<City> builder)
		{
			builder.Property(x => x.Name)
				.HasColumnName("NAME")
				.HasColumnOrder(2)
				.IsRequired()
				.HasColumnType("nvarchar(20)");
		}
	}
}
