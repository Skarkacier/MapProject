using Application.Dto;
using Application.Features.CQRS.Queries;
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
    public class CheckUserQueryHandler : IRequestHandler<CheckUserQueryRequest, CheckUserResponseDto?>
    {
        private readonly IRepository<User> userRepository;
        private readonly IRepository<UserRole> roleRepository;

        public CheckUserQueryHandler(IRepository<User> userRepository, IRepository<UserRole> roleRepository)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
        }

        public async Task<CheckUserResponseDto?> Handle(CheckUserQueryRequest request, CancellationToken cancellationToken)
        {
            var dto = new CheckUserResponseDto();
            var user = await this.userRepository.GetByFilterAsync(x => x.Username == request.Username && x.Password == request.Password);
            if (user == null)
            {
                dto.IsExist = false;
            }
            else
            {
                dto.IsExist = true;
                dto.Username = request.Username;
                dto.Role = (await this.roleRepository.GetByFilterAsync(x => x.Id == user.UserRoleId))?.Definition;
                dto.Id = user.Id;
            }
            return dto;
        }
    }
}
