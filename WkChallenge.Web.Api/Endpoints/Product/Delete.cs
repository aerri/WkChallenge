using AutoMapper;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WkChallenge.Core.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using WkChallenge.Web.Shared.ViewModels;
using WkChallenge.Web.Shared.ViewModels.Product;

namespace WkChallenge.Web.Api.Endpoints.Product;

public class Delete : EndpointBaseAsync.WithRequest<DeleteProductRequest>.WithActionResult<DeleteProductResponse>
{
	private readonly IMapper _mapper;
	private readonly IRepository<Core.Models.Product> _repository;

	public Delete(IMapper mapper, IRepository<Core.Models.Product> repository)
	{
		_mapper = mapper;
		_repository = repository;
	}

	[HttpDelete("api/products/{Id}")]
	[SwaggerOperation(Summary = "Deletes a Product", Description = "Deletes a Product", OperationId = "products.delete", Tags = new[] {"ProductEndpoints"})]
	public override async Task<ActionResult<DeleteProductResponse>> HandleAsync([FromRoute] DeleteProductRequest request, CancellationToken cancellationToken = new())
	{
		try
		{
			var toDelete = _mapper.Map<Core.Models.Product>(request);
			await _repository.DeleteAsync(toDelete, cancellationToken);
			var response = new DeleteProductResponse(request.CorrelationId);
			return Ok(response);
		}
		catch (DbUpdateConcurrencyException) { return NotFound(new NotFoundResponse(request.CorrelationId)); }
	}
}
