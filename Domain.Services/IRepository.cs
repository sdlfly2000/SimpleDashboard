namespace Domain.Services
{
    public interface IRepository<TKey,TAspect>
    {
        Task<TAspect> LoadById(TKey Id);

        Task Update(TAspect aspect);

        Task<TKey> Add(TAspect aspect);
    }
}
