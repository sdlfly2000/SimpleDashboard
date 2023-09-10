namespace Domain.UserStory
{
    public interface IUserStory : IUserStoryInformationAspect
    {
        public UserStoryReference UserStoryId { get; set; }
        public IList<ITaskAspect> Tasks { get; }
    }
}
