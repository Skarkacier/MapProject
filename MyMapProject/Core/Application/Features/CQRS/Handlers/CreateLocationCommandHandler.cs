using MediatR;
using MyMapProject.Core.Application.Features.CQRS.Commands;
using MyMapProject.Core.Application.Interfaces;
using MyMapProject.Core.Domain;

namespace MyMapProject.Core.Application.Features.CQRS.Handlers
{
    public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommandRequest>
    {
        private readonly IRepository<Location> repository;

        public CreateLocationCommandHandler(IRepository<Location> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(CreateLocationCommandRequest request, CancellationToken cancellationToken)
        {
            await this.repository.CreateAsync(new Location
            {
                CategoryId = request.CategoryId,
                Name = request.Name,
                X = request.X,
                Y = request.Y,
            });
            return Unit.Value;
        }
    }
}
