using Domain.UserRequirement;

namespace Domain.Services.UserStory.Repositories
{
    public interface IUserStoryRepository : IRepository<long, UserStoryInformationAspect>
    {
        Task<IList<UserStoryInformationAspect>> LoadByOwnerId(Guid id);
    }
}
