namespace WkChallenge.Web.Shared.ViewModels.Product;

public class GetProductResponse : BaseResponse
{
	public ProductDto Product { get; set; } = new();
	public GetProductResponse(Guid correlationId) : base(correlationId) { }
}
