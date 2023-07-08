﻿using Ahlatci.Shop.Domain.Common;
using Ahlatci.Shop.Domain.Entites;
using Ahlatci.Shop.Persistence.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Ahlatci.Shop.Persistence.Context
{
	public class AhlatciContext : DbContext
	{
		public AhlatciContext(DbContextOptions<AhlatciContext> options) : base(options) { }
		#region DbSet
		public DbSet<Account> Accounts { get; set; }
		public DbSet<Address> Addresses { get; set; }
		public DbSet<Catergory> Catergories { get; set; }
		public DbSet<City> Cities { get; set; }
		public DbSet<Comment> Comments { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderDetail> OrderDetails { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<ProductImage> ProductImages { get; set; }
		#endregion


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new AccountMapping());
			modelBuilder.ApplyConfiguration(new AddressMapping());
			modelBuilder.ApplyConfiguration(new CatergoryMapping());
			modelBuilder.ApplyConfiguration(new CityMapping());
			modelBuilder.ApplyConfiguration(new CommentMapping());
			modelBuilder.ApplyConfiguration(new CustomerMapping());
			modelBuilder.ApplyConfiguration(new OrderDetailMapping());
			modelBuilder.ApplyConfiguration(new OrderMapping());
			modelBuilder.ApplyConfiguration(new ProductImageMapping());
			modelBuilder.ApplyConfiguration(new ProductImageMapping());
		}

		public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
		{
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>().ToList())
            {
				switch (entry.State)
				{
					case EntityState.Modified:
						entry.Entity.ModifiedDate=DateTime.Now;
						entry.Entity.ModifiedBy = "admin";
						break;
					case EntityState.Added:
						entry.Entity.CreateDate = DateTime.Now;
						entry.Entity.CreatedBy = "admin";
						break;
					default:
						break;
				}
			}
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
		}
	}
}