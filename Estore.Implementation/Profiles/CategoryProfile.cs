using AutoMapper;
using Estore.Application.DataTransfer;
using Estore.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Estore.Implementation.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryGetDto>();
        }


    }
}
