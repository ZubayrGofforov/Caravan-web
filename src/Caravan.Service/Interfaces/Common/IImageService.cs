using Microsoft.AspNetCore.Http;

namespace Caravan.Service.Interfaces.Common;

public interface IImageService
{
    public Task<string> SaveImageAsync(IFormFile file);
    public Task<bool> DeleteImageAsync(string imagePath);
}
