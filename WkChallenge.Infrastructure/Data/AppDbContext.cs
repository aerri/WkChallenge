using WkChallenge.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace WkChallenge.Infrastructure.Data;

public class AppDbContext : DbContext
{
	public DbSet<Category>? Categories { get; set; }
	public DbSet<Product>? Products { get; set; }
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.UseSerialColumns();
	}
}
