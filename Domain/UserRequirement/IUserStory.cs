namespace Domain.UserRequirement
{
    public interface IUserStory : IUserStoryInformationAspect
    {
        public List<ITaskAspect> Tasks { get; }
    }
}
