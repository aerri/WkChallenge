using AutoMapper;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using WkChallenge.Core.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using WkChallenge.Core.Specifications.Product;
using WkChallenge.Web.Shared.ViewModels.Product;

namespace WkChallenge.Web.Api.Endpoints.Product;

public class List : EndpointBaseAsync.WithRequest<ListProductsRequest>.WithActionResult<ListProductsResponse>
{
	private readonly IMapper _mapper;
	private readonly IRepository<Core.Models.Product> _repository;

	public List(IMapper mapper, IRepository<Core.Models.Product> repository)
	{
		_mapper = mapper;
		_repository = repository;
	}

	[HttpGet("api/products")]
	[SwaggerOperation(Summary = "List Products", Description = "List Products", OperationId = "products.list", Tags = new[] {"ProductEndpoints"})]
	public override async Task<ActionResult<ListProductsResponse>> HandleAsync([FromQuery] ListProductsRequest request, CancellationToken cancellationToken = new())
	{
		var products = await _repository.ListAsync(new ListProductsIncludeCategorySpecs(), cancellationToken);
		var response = new ListProductsResponse(request.CorrelationId) {Products = _mapper.Map<List<ProductDto>>(products)};
		return Ok(response);
	}
}
