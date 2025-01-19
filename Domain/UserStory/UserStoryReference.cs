using SimpleDashboard.Common;

namespace Domain.UserStory
{
    public class UserStoryReference : Reference
    {
        public UserStoryReference(long code) : base(code.ToString(), CacheField.UserStory)
        {
        }
    }
}
