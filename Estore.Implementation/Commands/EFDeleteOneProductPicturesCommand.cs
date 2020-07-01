using Estore.Application.Commands;
using Estore.Application.DataTransfer;
using Estore.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Estore.Implementation.Commands
{
    public class EFDeleteOneProductPicturesCommand : IDeleteOneProductPicturesCommand
    {
        private readonly EstoreContext _context;

        public EFDeleteOneProductPicturesCommand(EstoreContext context)
        {
            _context = context;
        }

        public int Id => 11;

        public string Name => "Deleting one product pictures";

        public void Execute(IEnumerable<ProductPictureDto> request)
        {
            var query = _context.Pictures;
            foreach(var item in request)
            {
                var productPicture = query.Find(item.Id);
                _context.Pictures.Remove(productPicture);
            }
            _context.SaveChanges();
        }
    }
}
