using Estore.Application.Commands;
using Estore.Application.DataTransfer;
using Estore.DataAccess;
using Estore.Domain;
using Estore.Implementation.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Estore.Implementation.Commands
{
    public class EFCreateNewPictureCommand : ICreateNewPictureCommand
    {
        private readonly EstoreContext _context;

        public EFCreateNewPictureCommand(EstoreContext context)
        {
            _context = context;
        }

        public int Id => 9;

        public string Name => "Inserting new product pictures";

        public void Execute(NewProductPictureDto request)
        {
            var paths = UploadService.UploadImages(request.Pictures);

            for(int i = 0; i < paths.Count; i++)
            {
                var productPicture = new Picture
                {
                    ImagePath = paths[i],
                    ProductId = request.ProductId
                };
                _context.Pictures.Add(productPicture);

            }
            _context.SaveChanges();
        }
    }
}
