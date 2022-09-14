using AutoMapper;
using WkChallenge.Core.Models;
using WkChallenge.Web.Shared.ViewModels.Product;

namespace WkChallenge.Web.Api.MappingProfiles;

public class ProductProfile : Profile
{
	public ProductProfile()
	{
		CreateMap<Product, ProductDto>();
		CreateMap<CreateProductRequest, Product>();
	}
}
