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
	public class CatergoryMapping : AuditableEntityMapping<Catergory>
	{
		 
		public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Catergory> builder)
		{
			builder.Property(x => x.Name) // foreign key customer tablosu için
			   .IsRequired()
			   .HasColumnType("nvarchar(100)")
			   .HasColumnName("NAME")
			   .HasColumnOrder(2);

			builder.ToTable("CATERGORIES");
		}
	}
}
