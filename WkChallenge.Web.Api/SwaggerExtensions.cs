using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WkChallenge.Web.Api;

public static class SwaggerExtensions
{
	public class CustomOperationFilters : IOperationFilter
	{
		public void Apply(OpenApiOperation operation, OperationFilterContext context)
		{
			foreach (var parameter in operation.Parameters)
				if ("CorrelationId".Equals(parameter.Name))
					parameter.Required = false;
		}
	}
}
