using Common.Core.DependencyInjection;
using Microsoft.AspNetCore.Http;

namespace SimpleDashboard.Common.Middlewares
{
    [ServiceLocate(default)]
    public class CurrentContextAssignment : IMiddleware
    {
        private readonly CurrentContext _currentContext;

        public CurrentContextAssignment(CurrentContext currentContext)
        {
            _currentContext = currentContext;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _currentContext.User = UserContextUtil.GetCurrentUserId(context.Items["CacheJwtKey"] as string);

            await next.Invoke(context);
        }
    }
}
