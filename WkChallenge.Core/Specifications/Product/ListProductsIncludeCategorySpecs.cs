using Ardalis.Specification;

namespace WkChallenge.Core.Specifications.Product;

public sealed class ListProductsIncludeCategorySpecs : Specification<Models.Product>
{
	public ListProductsIncludeCategorySpecs() => Query.Include(product => product.Category);
}
