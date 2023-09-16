using AutoMapper;
using MyMapProject.Core.Application.Dto;
using MyMapProject.Core.Domain;

namespace MyMapProject.Core.Application.Mapping
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile() 
        {
            this.CreateMap<Category, CategoryListDto>().ReverseMap();
        }
    }
}
