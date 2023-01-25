using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caravan.Service.Common.Exceptions
{
    public class ModelErrorException : Exception
    {
        public string Property { get; set; } = String.Empty;

        public ModelErrorException(string property, string message)
            : base(message)
        {
            this.Property = property;
        }
    }
}
