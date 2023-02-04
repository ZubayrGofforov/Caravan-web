using Caravan.Domain.Common;
using Caravan.Domain.Enums;

namespace Caravan.Domain.Entities
{
    public class User : Auditable
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string? ImagePath { get; set; }

        public string Email { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public string Salt { get; set; } = string.Empty;

        public UserRole Role { get; set; } = UserRole.User;
    }
}
