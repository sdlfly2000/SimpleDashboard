namespace Application.UserRequirement
{
    public class AssignUserStoryResponse : IApplicationResponse
    {
        public AssignUserStoryResponse()
        {
            Exceptions = new List<Exception>();
        }

        public IList<Exception> Exceptions { get; set; }
        public bool IsSuccess { get => Exceptions.Any();}
    }
}
