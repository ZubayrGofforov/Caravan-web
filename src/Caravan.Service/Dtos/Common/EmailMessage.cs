using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caravan.Service.Dtos.Common
{
    public class EmailMessage
    {
        public string To { get; set; } = String.Empty;

        public string Subject { get; set; } = String.Empty;

        public string Body { get; set; } = String.Empty;
    }
}
