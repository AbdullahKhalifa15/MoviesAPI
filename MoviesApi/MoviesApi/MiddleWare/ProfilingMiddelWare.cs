using System.Diagnostics;

namespace MoviesApi.MiddleWare
{
    public class ProfilingMiddelWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ProfilingMiddelWare> _logger;

        public ProfilingMiddelWare(RequestDelegate next, ILogger<ProfilingMiddelWare> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            await _next(context);
            stopwatch.Stop();
            _logger.LogInformation($"Request '{context.Request.Path} took '{stopwatch.ElapsedMilliseconds}' to execute");

        }




    }
}
