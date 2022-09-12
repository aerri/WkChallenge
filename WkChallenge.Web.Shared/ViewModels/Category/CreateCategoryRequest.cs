using System.ComponentModel.DataAnnotations;

namespace WkChallenge.Web.Shared.ViewModels.Category;

public class CreateCategoryRequest : BaseRequest
{
	[StringLength(int.MaxValue, MinimumLength = 1)]
	public string Name { get; set; } = string.Empty;
}
