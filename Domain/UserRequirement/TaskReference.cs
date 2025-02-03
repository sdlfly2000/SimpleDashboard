using SimpleDashboard.Common;

namespace Domain.UserRequirement
{
    public class TaskReference : Reference
    {
        public TaskReference(long code) : base(code.ToString(), CacheField.Task)
        {
        }
    }
}
