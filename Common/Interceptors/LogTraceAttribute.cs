using ArxOne.MrAdvice.Advice;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using SimpleDashboard.Common.Extentions;
using SimpleDashboard.Common.Metric;
using System.Diagnostics;

namespace SimpleDashboard.Common.Interceptors
{
    public class LogTraceAttribute : Attribute, IMethodAsyncAdvice
    {
        private readonly EnumMetricMeasure _metricMeasure;

        public LogTraceAttribute(EnumMetricMeasure metricMeasure)
        {
            _metricMeasure = metricMeasure;
        }

        public async Task Advise(MethodAsyncAdviceContext context)
        {
            var stopWatch = Stopwatch.StartNew();

            var serviceProvider = context.GetMemberServiceProvider();

            var currentContext = serviceProvider?.GetRequiredService<CurrentContext>();

            var logger = serviceProvider?.GetRequiredService<ILogger>();

            logger?.Information($"Executing {context.Target}, Trace Id: {{TraceId}}", currentContext?.TraceId);

            await context.ProceedAsync();

            logger?.Information($"Executed {context.Target}, {{MetricMeasure}} in {{MetricExecutionTimeInMs}} ms, Trace Id: {{TraceId}}", _metricMeasure, stopWatch.ElapsedMilliseconds, currentContext?.TraceId);
        }
    }
}
