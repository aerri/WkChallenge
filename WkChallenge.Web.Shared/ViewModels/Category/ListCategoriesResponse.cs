namespace WkChallenge.Web.Shared.ViewModels.Category;

public class ListCategoriesResponse : BaseResponse
{
	public List<CategoryDto> Categories { get; set; } = new();
	public ListCategoriesResponse(Guid correlationId) : base(correlationId) { }
}
