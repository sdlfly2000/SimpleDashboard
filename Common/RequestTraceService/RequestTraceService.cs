using Common.Core.DependencyInjection;

namespace SimpleDashboard.Common.RequestTraceService
{
    [ServiceLocate(typeof(IRequestTraceService), ServiceType.Scoped)]
    public class RequestTraceService : IRequestTraceService
    {
        public string TraceId { get; set; }
    }
}
