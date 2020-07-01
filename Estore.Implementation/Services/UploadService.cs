using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Estore.Implementation.Services
{
    public static class UploadService
    {
        public static List<string> UploadImages(ICollection<IFormFile> files)
        {
            var imagePaths = new List<string>();
            foreach (var file in files)
            {
                var guid = Guid.NewGuid();
                var extension = Path.GetExtension(file.FileName);
                var newFileName = guid + extension;
                var path = Path.Combine("wwwroot", "Images", newFileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                imagePaths.Add(newFileName);
            }
            return imagePaths;
          
        }
        public static string UploadImage(IFormFile file)
        {
            var imagePath = "";

                var guid = Guid.NewGuid();
                var extension = Path.GetExtension(file.FileName);
                var newFileName = guid + extension;
                var path = Path.Combine("wwwroot", "Images", newFileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            imagePath = newFileName;
            
            return imagePath;

        }
    }
}
