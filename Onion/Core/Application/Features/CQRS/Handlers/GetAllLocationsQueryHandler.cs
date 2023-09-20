using Application.Dto;
using Application.Features.CQRS.Queries;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers
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
