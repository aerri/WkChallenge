namespace WkChallenge.Web.Shared.ViewModels.Product;

public class CreateProductResponse : BaseResponse
{
	public ProductDto Product { get; set; } = new();
	public CreateProductResponse(Guid correlationId) : base(correlationId) { }
}
