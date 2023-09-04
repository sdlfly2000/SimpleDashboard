namespace Domain.UserStory
{
    public interface IUserStory : IUserStoryInformationAspect
    {
        public IList<ITaskAspect> Tasks { get; }
    }
}
