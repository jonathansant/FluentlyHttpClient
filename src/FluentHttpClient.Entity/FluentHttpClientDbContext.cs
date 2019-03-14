﻿using System.Reflection;
using System.Threading.Tasks;
using FluentlyHttpClient.Caching;
using Microsoft.EntityFrameworkCore;

namespace FluentHttpClient.Entity
{
	public class FluentHttpClientDbContext : DbContext
	{
		public FluentHttpClientDbContext(DbContextOptions options)
			: base(options)
		{ }

		public DbSet<MessageItemStore> HttpResponses { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}

		public Task Initialize()
		{
			return Database.MigrateAsync();
		}

		public Task Commit()
		{
			return SaveChangesAsync();
		}
	}
}