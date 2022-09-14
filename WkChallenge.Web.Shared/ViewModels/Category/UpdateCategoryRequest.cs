using System.ComponentModel.DataAnnotations;

namespace WkChallenge.Web.Shared.ViewModels.Category;

public class UpdateCategoryRequest : BaseRequest
{
	[Range(1, int.MaxValue)]
	public int Id { get; set; }

	[StringLength(int.MaxValue, MinimumLength = 1)]
	public string Name { get; set; } = string.Empty;
}
