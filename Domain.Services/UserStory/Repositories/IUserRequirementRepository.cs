using Domain.UserRequirement;

namespace Domain.Services.UserStory.Repositories
{
    public interface IUserRequirementRepository : IRepository<long, UserRequirementEntity>
    {
        Task<IList<UserRequirementEntity>> LoadByOwnerId(Guid id);
    }
}
