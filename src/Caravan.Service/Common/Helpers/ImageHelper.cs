using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caravan.Service.Common.Helpers
{
    public class ImageHelper
    {
        public static string UniqueName(string fileName)
        {
            string extension = Path.GetExtension(fileName);
            string imageName = "IMG_" + Guid.NewGuid().ToString();
            return imageName + extension;
        }
    }
}
