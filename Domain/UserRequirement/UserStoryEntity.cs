namespace Domain.UserRequirement
{
    public class UserStoryEntity : BaseRecord
    {
        public UserStoryEntity()
        {
            Tasks = new List<TaskEntity>();
        }

        public UserStoryEntity(UserStoryReference reference)
        {
            Reference = reference;
            Tasks = new List<TaskEntity>();
        }

        public List<TaskEntity> Tasks { get; set; }
    }
}
