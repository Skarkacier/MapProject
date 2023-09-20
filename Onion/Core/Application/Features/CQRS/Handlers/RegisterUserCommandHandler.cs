using Application.Dto;
using Application.Enums;
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
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommandRequest, CreatedUserDto?>
    {
        private readonly IRepository<User> repository;
        private readonly IMapper mapper;

        public RegisterUserCommandHandler(IRepository<User> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<CreatedUserDto?> Handle(RegisterUserCommandRequest request, CancellationToken cancellationToken)
        {
            var data = await this.repository.CreateAsync(new User
            {
                Password = request.Password,
                Username = request.Username,
                UserRoleId = (int)RoleType.Member,
            });
            return this.mapper.Map<CreatedUserDto>(data);
        }
    }
}
