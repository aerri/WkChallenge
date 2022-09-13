using AutoMapper;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using WkChallenge.Core.Interfaces;
using WkChallenge.Web.Shared.ViewModels;
using Swashbuckle.AspNetCore.Annotations;
using WkChallenge.Web.Shared.ViewModels.Category;

namespace WkChallenge.Web.Api.Endpoints.Category;

public class GetById : EndpointBaseAsync.WithRequest<GetByIdCategoryRequest>.WithActionResult<GetByIdCategoryResponse>
{
	private readonly IMapper _mapper;
	private readonly IRepository<Core.Models.Category> _repository;

	public GetById(IRepository<Core.Models.Category> repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	[HttpGet("api/categories/{Id}")]
	[SwaggerOperation(Summary = "Get a Category by Id", Description = "Gets a Category by Id", OperationId = "categories.GetById", Tags = new[] {"CategoryEndpoints"})]
	public override async Task<ActionResult<GetByIdCategoryResponse>> HandleAsync([FromRoute] GetByIdCategoryRequest request, CancellationToken cancellationToken = new())
	{
		var response = new GetByIdCategoryResponse(request.CorrelationId);
		var category = await _repository.GetByIdAsync(request.Id, cancellationToken);
		if (category is null) return NotFound(new NotFoundResponse(request.CorrelationId));
		response.Category = _mapper.Map<CategoryDto>(category);
		return Ok(response);
	}
}
