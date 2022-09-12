namespace WkChallenge.Web.Shared.ViewModels.Category;

public class CreateCategoryResponse : BaseResponse
{
	public CategoryDto Category { get; set; } = new();
	public CreateCategoryResponse(Guid correlationId) : base(correlationId) { }
}
