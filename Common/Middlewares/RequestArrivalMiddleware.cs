using Common.Core.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SimpleDashboard.Common.RequestTraceService;

namespace SimpleDashboard.Common.Middlewares
{
    [ServiceLocate(default)]
    public class RequestArrivalMiddleware : IMiddleware
    {
        private readonly ILogger<RequestArrivalMiddleware> _logger;
        private readonly IRequestTraceService _requestTraceService;

        public RequestArrivalMiddleware(
            ILogger<RequestArrivalMiddleware> logger,
            IRequestTraceService requestTraceService,
            IServiceProvider serviceProvider)
        {
            _logger = logger;
            _requestTraceService = requestTraceService;
        }

        async Task IMiddleware.InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _requestTraceService.TraceId = Guid.NewGuid().ToString();

            await next.Invoke(context);
        }
    }
}
