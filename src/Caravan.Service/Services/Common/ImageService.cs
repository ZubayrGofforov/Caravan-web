using Caravan.Service.Common.Helpers;
using Caravan.Service.Interfaces.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caravan.Service.Services.Common
{
    public class ImageService : IImageService
    {
        private readonly string images = "Images";
        private readonly string rootPath ;
        public ImageService(IWebHostEnvironment environment)
        {
            rootPath = environment.WebRootPath;
        }

        public Task<bool> DeleteImageAsync(string imagePath)
        {
            string filePath = Path.Combine(rootPath, imagePath);
            if(!File.Exists(filePath)) return Task.FromResult(false);

            try
            {
                File.Delete(filePath);
                return Task.FromResult(true);
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }

        public async Task<string> SaveImageAsync(IFormFile file)
        {
            string ImageName = ImageHelper.UniqueName(file.FileName);
            string ImagePath = Path.Combine(rootPath,images,ImageName);
            var stream = new FileStream(ImagePath, FileMode.Create);
            try
            {
                await file.CopyToAsync(stream);
                return Path.Combine(images, ImageName);
            }
            catch 
            {

                return "";
            }
            finally { 
                stream.Close();
            }
        }
    }
}
