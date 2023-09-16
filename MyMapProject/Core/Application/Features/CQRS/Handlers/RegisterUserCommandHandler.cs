using MediatR;
using MyMapProject.Core.Application.Enums;
using MyMapProject.Core.Application.Features.CQRS.Commands;
using MyMapProject.Core.Application.Interfaces;
using MyMapProject.Core.Domain;

namespace MyMapProject.Core.Application.Features.CQRS.Handlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommandRequest>
    {
        private readonly IRepository<User> repository;

        public RegisterUserCommandHandler(IRepository<User> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(RegisterUserCommandRequest request, CancellationToken cancellationToken)
        {
            await this.repository.CreateAsync(new User
            {
                Password = request.Password,
                UserName = request.Username,
                UserRoleId = (int)RoleType.Member,
            });
            return Unit.Value;
        }
    }
}
