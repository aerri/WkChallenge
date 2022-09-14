namespace WkChallenge.Web.Shared.ViewModels.Product;

public class ListProductsResponse : BaseResponse
{
	public List<ProductDto> Products { get; set; } = new();
	public ListProductsResponse(Guid correlationId) : base(correlationId) { }
}
