using MediatR;
using MyMapProject.Core.Application.Features.CQRS.Commands;
using MyMapProject.Core.Application.Interfaces;
using MyMapProject.Core.Domain;

namespace MyMapProject.Core.Application.Features.CQRS.Handlers
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
