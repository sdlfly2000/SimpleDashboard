using Domain.User;

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

        public static UserRequirementEntity Create(UserReference CreatedBy)
        {
            var currentDateTime = DateTime.UtcNow;

            return new UserRequirementEntity()
            {
                Owner = CreatedBy,
                StartedOn = currentDateTime,
                Period = TimeSpan.FromDays(1), // Default period is 1 day
                Status = EnumRecordStatus.INITIAL,
                ModifiedOn = currentDateTime,
                ModifiedBy = CreatedBy,
                CreatedOn = currentDateTime,
                CreatedBy = CreatedBy
            };
        }
    }
}
