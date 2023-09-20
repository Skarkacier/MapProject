using Application.Dto;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public class UserProfile :Profile
    {
        public UserProfile() 
        {
            this.CreateMap<User, CreatedUserDto>().ReverseMap();
        }
    }
}
