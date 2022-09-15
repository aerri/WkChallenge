using AutoMapper;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using WkChallenge.Core.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using WkChallenge.Web.Shared.ViewModels;
using WkChallenge.Core.Specifications.Category;
using WkChallenge.Web.Shared.ViewModels.Product;

namespace WkChallenge.Web.Api.Endpoints.Product;

public class Update : EndpointBaseAsync.WithRequest<UpdateProductRequest>.WithActionResult<UpdateProductResponse>
{
	private readonly IMapper _mapper;
	private readonly IRepository<Core.Models.Category> _repository;

	public Update(IMapper mapper, IRepository<Core.Models.Category> repository)
	{
		_mapper = mapper;
		_repository = repository;
	}

	[HttpPut("api/products")]
	[SwaggerOperation(Summary = "Updates a Product", Description = "Updates a Product", OperationId = "products.update", Tags = new[] {"ProductEndpoints"})]
	public override async Task<ActionResult<UpdateProductResponse>> HandleAsync(UpdateProductRequest request, CancellationToken cancellationToken = new())
	{
		var spec = new CategoryByIdIncludeProductsSpecs(request.CategoryId);
		var category = await _repository.SingleOrDefaultAsync(spec, cancellationToken);
		if (category is null) return NotFound(new NotFoundResponse(request.CorrelationId));
		var productToUpadte = category.Products.FirstOrDefault(product => product.Id == request.Id);
		if (productToUpadte is null) return NotFound(new NotFoundResponse(request.CorrelationId));
		var response = new UpdateProductResponse(request.CorrelationId) {Product = _mapper.Map<ProductDto>(_mapper.Map(request, productToUpadte))};
		await _repository.UpdateAsync(category, cancellationToken);
		return Ok(response);
	}
}
