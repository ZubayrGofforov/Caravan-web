using Caravan.Service.Common.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Caravan.Service.Dtos.Users
{
    public class UserUpdateDto
    {
        [MaxLength(30), MinLength(2)]
        public string FirstName { get; set; } = string.Empty;

        [MaxLength(30), MinLength(2)]
        public string LastName { get; set; } = string.Empty;
        [MinLength(2)]
        public string Address { get; set; } = string.Empty;

        [PhoneNumberAttribute]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
