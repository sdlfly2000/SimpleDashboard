namespace Infra.Database.SQLServer.UserStory.Synchronizers
{
    public interface ISynchronize<in TAspect, TEntity>
        where TAspect : class
        where TEntity : class
    {
        Task<TEntity> Synchronize(TAspect aspect);
    }
}
