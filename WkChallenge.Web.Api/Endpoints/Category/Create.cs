using AutoMapper;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using WkChallenge.Core.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using WkChallenge.Web.Shared.ViewModels.Category;

namespace WkChallenge.Web.Api.Endpoints.Category;

public class Create : EndpointBaseAsync.WithRequest<CreateCategoryRequest>.WithActionResult<CreateCategoryResponse>
{
	private readonly IMapper _mapper;
	private readonly IRepository<Core.Models.Category> _repository;

	public Create(IRepository<Core.Models.Category> repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	[HttpPost("api/categories")]
	[SwaggerOperation(Summary = "Creates a new Category", Description = "Creates a new Category", OperationId = "categories.create", Tags = new[] {"CategoryEndpoints"})]
	public override async Task<ActionResult<CreateCategoryResponse>> HandleAsync(CreateCategoryRequest request, CancellationToken cancellationToken = new())
	{
		var toAdd = _mapper.Map<Core.Models.Category>(request);
		toAdd = await _repository.AddAsync(toAdd, cancellationToken);
		var response = new CreateCategoryResponse(request.CorrelationId) {Category = _mapper.Map<CategoryDto>(toAdd)};
		return Created($"api/categories/{toAdd}", response);
	}
}
