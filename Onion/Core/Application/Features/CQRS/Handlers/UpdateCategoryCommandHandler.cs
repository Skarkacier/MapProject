﻿using Application.Features.CQRS.Commands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest>
    {
        private readonly IRepository<Category> repository;

        public UpdateCategoryCommandHandler(IRepository<Category> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            //CONNECTED
            var updatedEntity = await this.repository.GetByIdAsync(request.Id);
            if (updatedEntity != null)
            {
                updatedEntity.Definition = request.Definition;
                await this.repository.SaveChangesAsync();
            }

            //DISCONNECTED
            //var updatedCategory = new Category()
            //{
            //    Definition = request.Definition,
            //    Id = request.Id,
            //};
            //await this.repository.UpdateAsync(updatedCategory);
            return Unit.Value;
        }
    }
}
