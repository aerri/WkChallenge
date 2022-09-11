using System.Reflection;
using Microsoft.EntityFrameworkCore;
using WkChallenge.Core.Models;

namespace WkChallenge.Infrastructure.Data;

public class AppDbContext : DbContext
{
	public DbSet<Product>? Products { get; set; }

	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		modelBuilder.UseSerialColumns();
	}
}
