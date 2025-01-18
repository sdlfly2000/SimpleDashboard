using Common.Core.AOP.Cache;

namespace Domain.Services
{
    public interface IRepository<TAspect, TEntity>
    {
        TAspect LoadById(Guid Id);

        void Update(TAspect aspect);

        void Add(TAspect aspect);
    }
}
