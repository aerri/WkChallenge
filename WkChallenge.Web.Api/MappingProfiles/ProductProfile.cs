using AutoMapper;
using WkChallenge.Core.Models;
using WkChallenge.Web.Shared.ViewModels.Product;

namespace WkChallenge.Web.Api.MappingProfiles;

public class ProductProfile : Profile
{
	public ProductProfile()
	{
		CreateMap<Product, ProductDto>().ForMember(dto => dto.Category, options => options.MapFrom(product => product.Category.Name));
		CreateMap<CreateProductRequest, Product>();
		CreateMap<UpdateProductRequest, Product>();
	}
}
