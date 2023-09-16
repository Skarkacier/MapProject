using AutoMapper;
using MyMapProject.Core.Application.Dto;
using MyMapProject.Core.Domain;

namespace MyMapProject.Core.Application.Mapping
{
    public class LocationProfile : Profile
    {
        public LocationProfile()
        {
            this.CreateMap<Location, LocationListDto>().ReverseMap();
        }
    }
}
