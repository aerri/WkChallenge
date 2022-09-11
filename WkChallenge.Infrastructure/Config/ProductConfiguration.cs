using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WkChallenge.Core.Models;

namespace WkChallenge.Infrastructure.Config;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
	public void Configure(EntityTypeBuilder<Product> builder)
	{
		builder.ToTable("Products").HasKey(product => product.Id);
		builder.HasOne(product => product.Category).WithMany();
	}
}
