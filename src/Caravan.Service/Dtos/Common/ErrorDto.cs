namespace Caravan.Service.Dtos.Common
{
    public class ErrorDto
    {
        public int StatusCode { get; set; }

        public string Message { get; set; } = string.Empty;
    }
}
