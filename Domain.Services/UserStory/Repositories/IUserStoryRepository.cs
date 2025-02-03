using Domain.UserRequirement;

namespace Domain.Services.UserStory.Repositories
{
    public interface IUserStoryRepository : IRepository<long, IUserStoryInformationAspect>
    {
        Task<IList<IUserStoryInformationAspect>> LoadByOwnerId(Guid id);
    }
}
