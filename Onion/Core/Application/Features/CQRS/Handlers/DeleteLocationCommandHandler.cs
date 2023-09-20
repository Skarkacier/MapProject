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
    public class DeleteLocationCommandHandler : IRequestHandler<DeleteLocationCommandRequest>
    {
        private readonly IRepository<Location> repository;

        public DeleteLocationCommandHandler(IRepository<Location> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(DeleteLocationCommandRequest request, CancellationToken cancellationToken)
        {
            var deletedEntity = await this.repository.GetByIdAsync(request.Id);
            if (deletedEntity != null)
                await this.repository.RemoveAsync(deletedEntity);
            return Unit.Value;
        }
    }
}
