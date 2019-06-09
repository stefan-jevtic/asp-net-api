using Microsoft.AspNetCore.Http;

namespace Application.Services.Interfaces
{
    public interface IImageService
    {
        string Upload(IFormFile file);
        void Delete(string image);
    }
}