using Domain.UserStory;

namespace Domain.Services.UserStory
{
    public interface IUserStoryPersistor
    {
        void Persist(IUserStory userStory);

        UserStoryReference Add(IUserStory userStory);
    }
}
