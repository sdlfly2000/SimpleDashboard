using ArxOne.MrAdvice.Advice;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using SimpleDashboard.Common.Extentions;
using SimpleDashboard.Common.RequestTraceService;
using System.Diagnostics;

namespace SimpleDashboard.Common.Interceptors
{
    public class LogTraceAttribute : Attribute, IMethodAsyncAdvice
    {
        public async Task Advise(MethodAsyncAdviceContext context)
        {
            var stopWatch = Stopwatch.StartNew();

            var serviceProvider = context.GetMemberServiceProvider();

            var requestTraceService = serviceProvider?.GetRequiredService<IRequestTraceService>();

            var logger = serviceProvider?.GetRequiredService<ILogger>();

            logger?.Information($"Executing {context.Target}, Trace Id: {{TraceId}}", requestTraceService?.TraceId);

            await context.ProceedAsync();

            logger?.Information($"Executed {{MetricExecutionTarget}} in {{MetricExecutionTimeInMs}} ms, Trace Id: {{TraceId}}", context.Target, stopWatch.ElapsedMilliseconds, requestTraceService?.TraceId);
        }
    }
}
