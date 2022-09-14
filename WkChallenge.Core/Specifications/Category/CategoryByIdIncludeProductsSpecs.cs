using Ardalis.Specification;

namespace WkChallenge.Core.Specifications.Category;

public sealed class CategoryByIdIncludeProductsSpecs : SingleResultSpecification<Models.Category>
{
	public CategoryByIdIncludeProductsSpecs(int categoryId) => Query.Include(category => category.Products).Where(category => category.Id == categoryId);
}
