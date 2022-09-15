using AutoMapper;
using WkChallenge.Core.Models;
using WkChallenge.Web.Shared.ViewModels.Category;

namespace WkChallenge.Web.Api.MappingProfiles;

public class CategoryProfile : Profile
{
	public CategoryProfile()
	{
		CreateMap<Category, CategoryDto>();
		CreateMap<CreateCategoryRequest, Category>();
		CreateMap<UpdateCategoryRequest, Category>();
		CreateMap<DeleteCategoryRequest, Category>();
	}
}
