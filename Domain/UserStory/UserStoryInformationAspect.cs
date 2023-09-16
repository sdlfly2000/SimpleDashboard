using Domain.User;

namespace Domain.UserStory
{
    public class UserStoryInformationAspect : IUserStoryInformationAspect
    {
        public UserStoryInformationAspect(UserStoryReference reference)
        {
            Id = reference;
        }

        public UserStoryReference Id { get; }

        public string Title { get; set; }
        public string Description { get; set; }
        public UserReference Owner { get; set; }
        public DateTime StartedOn { get; set; }
        public TimeSpan Period { get; set; }
        public UserStroyStatus Status { get; set; }
        public DateTime ModifiedOn { get; set; }
        public UserReference ModifiedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public UserReference CreatedBy { get; set; }
    }
}
