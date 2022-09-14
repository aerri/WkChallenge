using System.ComponentModel.DataAnnotations;

namespace WkChallenge.Web.Shared.ViewModels.Product;

public class CreateProductRequest : BaseRequest
{
	[StringLength(int.MaxValue, MinimumLength = 1)]
	public string Name { get; set; } = string.Empty;

	[Range(1, int.MaxValue)]
	public int CategoryId { get; set; }
}
