namespace WkChallenge.Web.Shared.ViewModels.Category;

public class GetByIdCategoryResponse : BaseResponse
{
	public CategoryDto Category { get; set; } = new();
	public GetByIdCategoryResponse(Guid correlationId) : base(correlationId) { }
}
