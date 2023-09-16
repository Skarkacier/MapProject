using MediatR;
using MyMapProject.Core.Application.Features.CQRS.Commands;
using MyMapProject.Core.Application.Interfaces;
using MyMapProject.Core.Domain;

namespace MyMapProject.Core.Application.Features.CQRS.Handlers
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
                await this.repository.UpdateAsync(updatedLocation);
            }

            return Unit.Value;
        }
    }
}
