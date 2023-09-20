using Application.Features.CQRS.Commands;
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
    public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommandRequest>
    {
        private readonly IRepository<Location> repository;

        public UpdateLocationCommandHandler(IRepository<Location> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(UpdateLocationCommandRequest request, CancellationToken cancellationToken)
        {
            var updatedLocation = await this.repository.GetByIdAsync(request.Id);
            if (updatedLocation != null)
            {
                updatedLocation.X = request.X;
                updatedLocation.Y = request.Y;
                updatedLocation.Name = request.Name;
                updatedLocation.CategoryId = request.CategoryId;
                await this.repository.SaveChangesAsync();
            }

            return Unit.Value;
        }
    }
}
