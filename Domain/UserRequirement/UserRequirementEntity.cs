namespace Domain.UserRequirement
{
    public class UserRequirementEntity : BaseRecord
    {
        public UserRequirementEntity()
        {
            UserStories = new List<UserStoryEntity>();
        }

        public UserRequirementEntity(UserRequirementReference reference)
        {
            Reference = reference;
            UserStories = new List<UserStoryEntity>();
        }

        public List<UserStoryEntity> UserStories { get; set; }
    }
}
