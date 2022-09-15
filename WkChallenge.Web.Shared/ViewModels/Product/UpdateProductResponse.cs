namespace WkChallenge.Web.Shared.ViewModels.Product;

public class UpdateProductResponse : BaseResponse
{
	public ProductDto Product { get; set; } = new();
	public UpdateProductResponse(Guid correlationId) : base(correlationId) { }
}
