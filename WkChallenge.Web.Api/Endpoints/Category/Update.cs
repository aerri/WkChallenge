using AutoMapper;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using WkChallenge.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using WkChallenge.Web.Shared.ViewModels;
using Swashbuckle.AspNetCore.Annotations;
using WkChallenge.Web.Shared.ViewModels.Category;

namespace WkChallenge.Web.Api.Endpoints.Category;

public class Update : EndpointBaseAsync.WithRequest<UpdateCategoryRequest>.WithActionResult<UpdateCategoryResponse>
{
	private readonly IMapper _mapper;
	private readonly IRepository<Core.Models.Category> _repository;

	public Update(IMapper mapper, IRepository<Core.Models.Category> repository)
	{
		_mapper = mapper;
		_repository = repository;
	}

	[HttpPut("api/categories")]
	[SwaggerOperation(Summary = "Updates a Category", Description = "Updates a Category", OperationId = "categories.update", Tags = new[] {"CategoryEndpoints"})]
	public override async Task<ActionResult<UpdateCategoryResponse>> HandleAsync(UpdateCategoryRequest request, CancellationToken cancellationToken = new())
	{
		try
		{
			var toUpdate = _mapper.Map<Core.Models.Category>(request);
			await _repository.UpdateAsync(toUpdate, cancellationToken);
			var response = new UpdateCategoryResponse(request.CorrelationId) {Category = _mapper.Map<CategoryDto>(toUpdate)};
			return Ok(response);
		}
		catch (DbUpdateConcurrencyException) { return NotFound(new NotFoundResponse(request.CorrelationId)); }
	}
}
