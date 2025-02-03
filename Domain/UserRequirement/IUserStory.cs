namespace Domain.UserRequirement
{
    public interface IUserStory : IUserStoryInformationAspect
    {
        public List<TaskAspect> Tasks { get; }
    }
}
