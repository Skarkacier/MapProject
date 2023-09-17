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
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, CreatedCategoryDto?>
    {
        private readonly IRepository<Category> repository;
        private readonly IMapper mapper;

        public CreateCategoryCommandHandler(IRepository<Category> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<CreatedCategoryDto?> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var category = new Category { Definition = request.Definition };
            var result = await this.repository.CreateAsync(category);

            return this.mapper.Map<CreatedCategoryDto>(result);
        }

    }
}

