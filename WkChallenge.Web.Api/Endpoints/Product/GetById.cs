using AutoMapper;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using WkChallenge.Core.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using WkChallenge.Core.Specifications.Product;
using WkChallenge.Web.Shared.ViewModels.Product;

namespace WkChallenge.Web.Api.Endpoints.Product;

public class GetById : EndpointBaseAsync.WithRequest<GetProductRequest>.WithActionResult<GetProductResponse>
{
	private readonly IMapper _mapper;
	private readonly IRepository<Core.Models.Product> _repository;

	public GetById(IMapper mapper, IRepository<Core.Models.Product> repository)
	{
		_mapper = mapper;
		_repository = repository;
	}

	[HttpGet("api/products/{Id}")]
	[SwaggerOperation(Summary = "Get a Product by Id", Description = "Gets a Product by Id", OperationId = "products.get", Tags = new[] {"ProductEndpoints"})]
	public override async Task<ActionResult<GetProductResponse>> HandleAsync([FromRoute] GetProductRequest request, CancellationToken cancellationToken = new())
	{
		var response = new GetProductResponse(request.CorrelationId);
		var product = await _repository.SingleOrDefaultAsync(new ProductByIdIncludeCategorySpecs(request.Id), cancellationToken);
		if (product is null) return NotFound();
		response.Product = _mapper.Map<ProductDto>(product);
		return Ok(response);
	}
}
