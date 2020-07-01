using AutoMapper;
using Estore.Application.DataTransfer;
using Estore.Application.Queries;
using Estore.Application.Searches;
using Estore.DataAccess;
using Estore.Domain;
using Estore.Implementation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Estore.Implementation.Queries
{
    public class EFGetUsersQuery : IGetUsersQuery
    {
        private readonly EstoreContext _context;
        private readonly IMapper _mapper;
        

        public EFGetUsersQuery(EstoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 20;

        public string Name => "Getting all users by search";

        public PageResponse<UserDto> Execute(UserSearch search)
        {
            var query = _context.Users.AsQueryable();
            if (!string.IsNullOrEmpty(search.Value) || !string.IsNullOrWhiteSpace(search.Value))
            {
                query = query.Where(x => x.FirstName.ToLower().Contains(search.Value.ToLower()) || x.LastName.ToLower().Contains(search.Value.ToLower()) || x.Email.ToLower().Contains(search.Value.ToLower()) || x.PID.ToString().Contains(search.Value));
            }

            return query.Paged<UserDto, User>(search, _mapper);
        }
    }
}
