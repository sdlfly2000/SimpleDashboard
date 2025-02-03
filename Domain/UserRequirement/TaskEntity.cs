namespace Domain.UserRequirement
{
    public class TaskEntity : BaseRecord
    {
        public TaskEntity()
        {
        }

        public TaskEntity(TaskReference reference)
        {
            Reference = reference;
        }
    }
}
