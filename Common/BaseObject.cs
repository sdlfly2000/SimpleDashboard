namespace SimpleDashboard.Common
{
    public abstract class BaseObject
    {
        private readonly IServiceProvider _serviceProvider;

        protected BaseObject(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
    }
}
