using AutoMapper;
using Estore.Application.DataTransfer;
using Estore.Application.Queries;
using Estore.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Estore.Implementation.Queries
{
    public class EFGetCategoriesQuery : IGetCategoriesQuery
    {
        private readonly EstoreContext _context;
        private readonly IMapper _mapper;

        public EFGetCategoriesQuery(EstoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 23;

        public string Name => "Getting all categories";

        public IEnumerable<CategoryDto> Execute(CategoryDto search)
        {
            var categories = _context.Categories.AsQueryable();

            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                categories = categories.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }

            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }
    }
}
