using Caravan.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caravan.Domain.Entities
{
    public class Administrator : Auditable
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public string Salt { get; set; } = string.Empty;

        public string ImagePath { get; set; } = string.Empty;

        public string PassportSeria { get; set; } = string.Empty;

        public string PassportNumber { get; set; } = string.Empty;
    }
}
