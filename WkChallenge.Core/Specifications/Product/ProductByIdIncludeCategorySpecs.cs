using Ardalis.Specification;

namespace WkChallenge.Core.Specifications.Product;

public sealed class ProductByIdIncludeCategorySpecs : SingleResultSpecification<Models.Product>
{
	public ProductByIdIncludeCategorySpecs(int productId) => Query.Where(product => product.Id == productId).Include(product => product.Category);
}
