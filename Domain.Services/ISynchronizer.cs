namespace Domain.Services
{
    public interface ISynchronizer<in TAspect, out TEntity> 
        where TAspect : class
        where TEntity : class
    {
        TEntity Synchronize(TAspect aspect);
    }
}
