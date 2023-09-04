using SimpleDashboard.Common;

namespace Domain.UserStory
{
    public class TaskReference : Reference
    {
        public TaskReference(string code) : base(code, CacheField.Task)
        {            
        }
    }
}
