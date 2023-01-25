using Caravan.Service.Dtos.Common;

namespace Caravan.Service.Interfaces.Common
{
    public interface IEmailService
    {
        public Task<bool> SendAsync(EmailMessage emailMessage);
    }
}
