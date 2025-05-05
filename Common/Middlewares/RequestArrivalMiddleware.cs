using Common.Core.DependencyInjection;
using Microsoft.AspNetCore.Http;

namespace SimpleDashboard.Common.Middlewares
{
    [ServiceLocate(default)]
    public class RequestArrivalMiddleware : IMiddleware
    {
        private readonly CurrentContext _currentContext;

        public RequestArrivalMiddleware(CurrentContext currentContext)
        {
            _currentContext = currentContext;
        }

        async Task IMiddleware.InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _currentContext.TraceId = Guid.NewGuid().ToString();

            await next.Invoke(context);
        }
    }
}
