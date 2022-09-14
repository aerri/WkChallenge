using AutoMapper;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using WkChallenge.Core.Interfaces;
using WkChallenge.Web.Shared.ViewModels;
using Swashbuckle.AspNetCore.Annotations;
using WkChallenge.Core.Specifications.Category;
using WkChallenge.Web.Shared.ViewModels.Product;

namespace WkChallenge.Web.Api.Endpoints.Product;

public class Create : EndpointBaseAsync.WithRequest<CreateProductRequest>.WithActionResult<CreateProductResponse>
{
	private readonly IMapper _mapper;
	private readonly IRepository<Core.Models.Category> _repository;

	public Create(IRepository<Core.Models.Category> repository, IMapper mapper)
	{
		_mapper = mapper;
		_repository = repository;
	}

	[HttpPost("api/products")]
	[SwaggerOperation(Summary = "Creates a new Product", Description = "Creates a new Product", OperationId = "products.create", Tags = new[] {"ProductEndpoints"})]
	public override async Task<ActionResult<CreateProductResponse>> HandleAsync(CreateProductRequest request, CancellationToken cancellationToken = new())
	{
		var spec = new CategoryByIdIncludeProductsSpecs(request.CategoryId);
		var category = await _repository.SingleOrDefaultAsync(spec, cancellationToken);
		if (category is null) return NotFound(new NotFoundResponse(request.CorrelationId));
		var newProduct = _mapper.Map<Core.Models.Product>(request);
		category.Products.Add(newProduct);
		await _repository.UpdateAsync(category, cancellationToken);
		var response = new CreateProductResponse(request.CorrelationId) {Product = _mapper.Map<ProductDto>(newProduct)};
		return Created($"api/products/{newProduct.Id}", response);
	}
}
