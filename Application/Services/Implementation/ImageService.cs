using System;
using System.IO;
using Application.Services.Interfaces;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Http;

namespace Application.Services.Implementation
{
    public class ImageService : IImageService
    {
        public string Upload(IFormFile file)
        {
            var fileName = file.FileName;
            var extension = Path.GetExtension(file.FileName);
            var name = "images/" + AuthMiddleware.ComputeSha256Hash(DateTime.UtcNow.ToTimestamp() + fileName) + extension;
            var path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()) + "/WebApp", "wwwroot", name);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            return name;
        }

        public void Delete(string image)
        {
            var path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()) + "/WebApp", "wwwroot", image);
            System.IO.File.Delete(path);
        }
    }
}