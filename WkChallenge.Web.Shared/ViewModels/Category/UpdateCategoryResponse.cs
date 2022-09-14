namespace WkChallenge.Web.Shared.ViewModels.Category;

public class UpdateCategoryResponse : BaseResponse
{
	public CategoryDto Category { get; set; } = new();
	public UpdateCategoryResponse(Guid correlationId) : base(correlationId) { }
}
