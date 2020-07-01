using AutoMapper;
using Estore.Application.DataTransfer;
using Estore.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Estore.Implementation.Profiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<Role, RoleDto>();
        }

        
    }
}
