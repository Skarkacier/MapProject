﻿using Application.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Commands
{
    public class RegisterUserCommandRequest : IRequest<CreatedUserDto?>
    {
        public string? Username { get; set; } = null!;
        public string? Password { get; set; } = null!;
    }
}
