using Application.Dto;
using Application.Features.CQRS.Commands;
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
    public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommandRequest, CreatedLocationDto>
    {
        private readonly IRepository<Location> repository;
        private readonly IMapper mapper;

        public CreateLocationCommandHandler(IRepository<Location> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<CreatedLocationDto?> Handle(CreateLocationCommandRequest request, CancellationToken cancellationToken)
        {
            var data = await this.repository.CreateAsync(new Location
            {
                CategoryId = request.CategoryId,
                Name = request.Name,
                X = request.X,
                Y = request.Y,
            });
            return this.mapper.Map<CreatedLocationDto>(data);
        }

    }
}
