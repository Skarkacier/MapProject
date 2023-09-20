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
