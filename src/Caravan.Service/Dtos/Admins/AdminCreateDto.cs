using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caravan.Service.Dtos.Admins
{
    public class AdminCreateDto
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
        
        public string ImagePath { get; set; } = string.Empty;

        public string PassportSeria { get; set; } = string.Empty;

        public string PassportNumber { get; set; } = string.Empty;
    }
}
