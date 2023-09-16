using AutoMapper;
using MediatR;
using MyMapProject.Core.Application.Dto;
using MyMapProject.Core.Application.Features.CQRS.Queries;
using MyMapProject.Core.Application.Interfaces;
using MyMapProject.Core.Domain;

namespace MyMapProject.Core.Application.Features.CQRS.Handlers
{
    public class GetAllLocationsQueryHandler : IRequestHandler<GetAllLocationsQueryRequest, List<LocationListDto>>
    {
        private readonly IRepository<Location> repository;
        private readonly IMapper mapper;

        public GetAllLocationsQueryHandler(IRepository<Location> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<List<LocationListDto>> Handle(GetAllLocationsQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await this.repository.GetAllAsync();
            return this.mapper.Map<List<LocationListDto>>(data);
        }
    }
}
