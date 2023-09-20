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
    internal class LocationProfile : Profile
    {
        public LocationProfile()
        {
            this.CreateMap<Location, LocationListDto>().ReverseMap();
            this.CreateMap<Location, CreatedLocationDto>().ReverseMap();
        }
    }
}
