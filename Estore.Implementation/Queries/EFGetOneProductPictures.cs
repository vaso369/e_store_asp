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
    public class EFGetOneProductPictures : IGetOneProductPicturesQuery
    {
        private readonly EstoreContext _context;
        private readonly IMapper _mapper;

        public EFGetOneProductPictures(EstoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 10;

        public string Name => "Getting one product pictures for product updating pictures";

        public IEnumerable<ProductPictureDto> Execute(int search)
        {
            var query = _context.Pictures.Where(p => p.ProductId == search);

            return _mapper.Map<IEnumerable<ProductPictureDto>>(query);
        }
    }
}
