using AutoMapper;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using WkChallenge.Core.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using WkChallenge.Web.Shared.ViewModels.Category;

namespace WkChallenge.Web.Api.Endpoints.Category;

public class Delete : EndpointBaseAsync.WithRequest<DeleteCategoryRequest>.WithActionResult<DeleteCategoryResponse>
{
	private readonly IMapper _mapper;
	private readonly IRepository<Core.Models.Category> _repository;

	public Delete(IMapper mapper, IRepository<Core.Models.Category> repository)
	{
		_mapper = mapper;
		_repository = repository;
	}

	[HttpDelete("api/categories/{Id}")]
	[SwaggerOperation(Summary = "Deletes a Category", Description = "Deletes a Category", OperationId = "categories.delete", Tags = new[] {"CategoryEndpoints"})]
	public override async Task<ActionResult<DeleteCategoryResponse>> HandleAsync([FromRoute] DeleteCategoryRequest request, CancellationToken cancellationToken = new())
	{
		var response = new DeleteCategoryResponse(request.CorrelationId);
		var toDelete = _mapper.Map<Core.Models.Category>(request);
		await _repository.DeleteAsync(toDelete, cancellationToken);
		return Ok(response);
	}
}
