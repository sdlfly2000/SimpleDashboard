namespace Domain.Services
{
    public interface IRepository<TAspect>
    {
        Task<TAspect> LoadById(Guid Id);

        Task Update(TAspect aspect);

        Task Add(TAspect aspect);
    }
}
