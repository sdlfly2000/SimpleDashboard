namespace Application.UserStory
{
    public class CreateUserStoryRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Owner { get; set; }
        public DateTime StartedOn { get; set; }
        public TimeSpan Period { get; set; }
        public string Status { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
    }
}
