namespace WkChallenge.Web.Shared.ViewModels.Product;

public class ProductDto
{
	public int Id { get; set; }
	public string Name { get; set; } = string.Empty;
	public int CategoryId { get; set; }
	public string Category { get; set; } = string.Empty;
}
