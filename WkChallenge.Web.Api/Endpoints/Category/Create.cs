using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WkChallenge.Core.Interfaces;
using WkChallenge.Web.Shared.ViewModels.Category;

namespace WkChallenge.Web.Api.Endpoints.Category;

public class Create : EndpointBaseAsync.WithRequest<CreateCategoryRequest>.WithActionResult<CreateCategoryResponse>
{
	private readonly IRepository<Core.Models.Category> _repository;
	private readonly IMapper _mapper;

	public Create(IRepository<Core.Models.Category> repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	[HttpPost("api/categories")]
	[SwaggerOperation(Summary = "Creates a new Category", Description = "Creates a new Category", OperationId = "categories.create", Tags = new[] {"CategoryEndpoints"})]
	public override async Task<ActionResult<CreateCategoryResponse>> HandleAsync(CreateCategoryRequest request, CancellationToken cancellationToken = new())
	{
		var response = new CreateCategoryResponse(request.CorrelationId);
		var toAdd = _mapper.Map<Core.Models.Category>(request);
		toAdd = await _repository.AddAsync(toAdd, cancellationToken);
		var dto = _mapper.Map<CategoryDto>(toAdd);
		response.Category = dto;
		return Ok(response);
	}
}
