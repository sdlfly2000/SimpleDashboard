using Common.Core.AOP.Cache;
using Domain.User;

namespace Domain.UserStory
{
    public class UserStoryDomain : IUserStory
    {
        private readonly IUserStoryInformationAspect _userStoryInformationAspect;

        public UserStoryDomain(IUserStoryInformationAspect userStoryInformationAspect)
        {
            _userStoryInformationAspect = userStoryInformationAspect;
            Tasks = new List<ITaskAspect>();
        }

        public List<ITaskAspect> Tasks { get; }

        public string Title { get => _userStoryInformationAspect.Title; set => _userStoryInformationAspect.Title = value; }
        public string Description { get => _userStoryInformationAspect.Description; set => _userStoryInformationAspect.Description = value; }
        public UserReference Owner { get => _userStoryInformationAspect.Owner; set => _userStoryInformationAspect.Owner = value; }
        public DateTime StartedOn { get => _userStoryInformationAspect.StartedOn; set => _userStoryInformationAspect.StartedOn = value; }
        public TimeSpan Period { get => _userStoryInformationAspect.Period; set => _userStoryInformationAspect.Period = value; }
        public UserStroyStatus Status { get => _userStoryInformationAspect.Status; set => _userStoryInformationAspect.Status = value; }
        public DateTime ModifiedOn { get => _userStoryInformationAspect.ModifiedOn; set => _userStoryInformationAspect.ModifiedOn = value; }
        public UserReference ModifiedBy { get => _userStoryInformationAspect.ModifiedBy; set => _userStoryInformationAspect.ModifiedBy = value; }
        public DateTime CreatedOn { get => _userStoryInformationAspect.CreatedOn; set => _userStoryInformationAspect.CreatedOn = value; }
        public UserReference CreatedBy { get => _userStoryInformationAspect.CreatedBy; set => _userStoryInformationAspect.CreatedBy = value; }
        public IReference Reference { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
