namespace Caravan.Service.ViewModels
{
    public class UserViewModel
    {
        public long Id { get; set; }
        
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string? ImagePath { get; set; }

        public string Email { get; set; } = string.Empty;
    }
}
