namespace Caravan.Api.Middlewares
{
    public class RequestRegisterMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _env;

        public RequestRegisterMiddleware(RequestDelegate next, IWebHostEnvironment env)
        {
            this._next = next;
            this._env = env;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            string path = Path.Combine(_env.WebRootPath, "requests", "Requests.txt");
            string content = httpContext.Request.Method + "--> " +
                             httpContext.Request.Path + "--> " +
                             DateTime.Now + "--> " +
                             httpContext.Connection.RemoteIpAddress + "--> " +
                             httpContext.Request.Headers["User-Agent"] + "\n";
            await File.AppendAllTextAsync(path, content);
            //httpContext.Response.Headers.Add("kattta", "bola");
            await _next(httpContext);
        }
    }
}
