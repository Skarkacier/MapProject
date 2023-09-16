using AutoMapper;
using MediatR;
using MyMapProject.Core.Application.Dto;
using MyMapProject.Core.Application.Features.CQRS.Queries;
using MyMapProject.Core.Application.Interfaces;
using MyMapProject.Core.Domain;

namespace MyMapProject.Core.Application.Features.CQRS.Handlers
{
    public class GetLocationQueryHandler : IRequestHandler<GetLocationQueryRequest, LocationListDto?>
    {
        private readonly IRepository<Location> repository;
        private readonly IMapper mapper;

        public GetLocationQueryHandler(IRepository<Location> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<LocationListDto?> Handle(GetLocationQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await this.repository.GetByFilterAsync(x => x.Id == request.Id);
            return this.mapper.Map<LocationListDto>(data);
        }
    }
}
