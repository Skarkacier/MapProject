using MediatR;
using MyMapProject.Core.Application.Dto;
using MyMapProject.Core.Application.Features.CQRS.Queries;
using MyMapProject.Core.Application.Interfaces;
using MyMapProject.Core.Domain;

namespace MyMapProject.Core.Application.Features.CQRS.Handlers
{
    public class CheckUserRequestHandler : IRequestHandler<CheckUserQueryRequest, CheckUserResponseDto>
    {
        private readonly IRepository<User> userRepository;
        private readonly IRepository<UserRole> roleRepository;

        public CheckUserRequestHandler(IRepository<User> userRepository, IRepository<UserRole> roleRepository)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
        }

        public async Task<CheckUserResponseDto> Handle(CheckUserQueryRequest request, CancellationToken cancellationToken)
        {
            var dto = new CheckUserResponseDto();
            var user = await this.userRepository.GetByFilterAsync(x => x.UserName == request.Username && x.Password == request.Password);

            if (user == null)
            {
                dto.IsExist = false;
            }
            else
            {
                dto.Username = user.UserName;
                dto.Id = user.Id;
                dto.IsExist = true;
                var role = await this.roleRepository.GetByFilterAsync(x => x.Id == user.UserRoleId);
                dto.Role = role?.Definition;
            }
            return dto;
        }
    }
}
