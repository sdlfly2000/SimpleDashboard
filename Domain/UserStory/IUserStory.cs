namespace Domain.UserStory
{
    public interface IUserStory : IUserStoryInformationAspect
    {
        public List<ITaskAspect> Tasks { get; }
    }
}
