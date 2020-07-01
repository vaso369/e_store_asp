using AutoMapper;
using Estore.Application.DataTransfer;
using Estore.Application.Queries;
using Estore.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Estore.Implementation.Queries
{
    public class EFGetOneUserQuery : IGetOneUserQuery
    {
        private readonly EstoreContext _context;
        private readonly IMapper _mapper;

        public EFGetOneUserQuery(EstoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 19;

        public string Name => "Getting one user info";

        public UserDto Execute(int search)
        {
            var user = _context.Users.Find(search);

            return _mapper.Map<UserDto>(user);

        }
    }
}
