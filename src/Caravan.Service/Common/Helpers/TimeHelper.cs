using Caravan.Service.Common.Constants;

namespace Caravan.Service.Common.Helpers
{
    public class TimeHelper
    {
        public static DateTime GetCurrentServerTime()
        {
            return DateTime.UtcNow.AddHours(TimeConstants.UTC);
        }
    }
}
