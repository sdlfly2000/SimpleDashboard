using Common.Core.DependencyInjection;

namespace SimpleDashboard.Common
{
    [ServiceLocate(default, ServiceType.Scoped)]
    public class CurrentContext
    {
        public Guid User { get; set;}

        public string TraceId { get; set; }
    }
}
