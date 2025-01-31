namespace SimpleDashboard.Common.Exceptions
{
    public class NotFoundFromDatabaseException<TEntity> : Exception where TEntity : class
    {
        public NotFoundFromDatabaseException(string key)
            : base($"{typeof(TEntity).Name} is not found by key: {key}")
        {

        }
    }
}
