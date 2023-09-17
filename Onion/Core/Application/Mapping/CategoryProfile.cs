using Application.Dto;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            this.CreateMap<Category, CategoryListDto>().ReverseMap();
            this.CreateMap<Category, CreatedCategoryDto>().ReverseMap();
        }
    }
}
