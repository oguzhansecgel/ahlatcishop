using Ahlatci.Shop.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahlatci.Shop.Persistence.Mappings
{
	public abstract class AuditableEntityMapping<T> : IEntityTypeConfiguration<T> where T : AuditableEntity
	{
		public abstract void ConfigureDerivedEntityMapping(EntityTypeBuilder<T> builder);

		public void Configure(EntityTypeBuilder<T> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id)
				.HasColumnName("ID")
				.HasColumnOrder(1);

			ConfigureDerivedEntityMapping(builder);


	
			builder.Property(x => x.CreateDate)
			   .HasColumnName("CREATE_DATE")
			   .HasColumnOrder(26);

			builder.Property(x => x.CreatedBy)
			   .HasColumnName("CREATE_BY")
			   .HasColumnOrder(27);

			builder.Property(x => x.ModifiedDate)
			   .HasColumnName("MODIFIED_DATE")
			   .HasColumnOrder(28);

			builder.Property(x => x.ModifiedBy)
			   .HasColumnName("MODIFIED_BY")
			   .HasColumnOrder(29);

			builder.Property(x => x.IsDeleted)
		.HasColumnName("IS_DELETED")
		.HasColumnOrder(30)
		.HasDefaultValueSql("0");

		}




	}
}
