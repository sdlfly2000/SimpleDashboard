using SimpleDashboard.Common;

namespace Domain.UserRequirement
{
    public class UserStoryReference : Reference
    {
        public UserStoryReference(long code) : base(code.ToString(), CacheField.UserStory)
        {
        }
    }
}
