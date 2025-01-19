using SimpleDashboard.Common;

namespace Domain.UserStory
{
    public class TaskReference : Reference
    {
        public TaskReference(long code) : base(code.ToString(), CacheField.Task)
        {            
        }
    }
}
