using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WkChallenge.Core.Interfaces;
using WkChallenge.Web.Shared.ViewModels.Category;

namespace WkChallenge.Web.Api.Endpoints.Category;

public class List : EndpointBaseAsync.WithRequest<ListCategoriesRequest>.WithActionResult<ListCategoriesResponse>
{
	private readonly IMapper _mapper;
	private readonly IRepository<Core.Models.Category> _repository;

	public List(IRepository<Core.Models.Category> repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	[HttpGet("api/categories")]
	[SwaggerOperation(Summary = "List Categories", Description = "List Categories", OperationId = "categories.list", Tags = new[] {"CategoryEndpoints"})]
	public override async Task<ActionResult<ListCategoriesResponse>> HandleAsync([FromQuery] ListCategoriesRequest request, CancellationToken cancellationToken = new())
	{
		var response = new ListCategoriesResponse(request.CorrelationId);
		var categories = await _repository.ListAsync(cancellationToken);
		response.Categories = _mapper.Map<List<CategoryDto>>(categories);
		return Ok(response);
	}
}
