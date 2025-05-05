
namespace Application.UserRequirement
{
    public class CreateUserRequirementResponse : IApplicationResponse
    {
        public CreateUserRequirementResponse()
        {
            Exceptions = new List<Exception>();
        }

        public long UserRequirementId { get; set; }

        public IList<Exception> Exceptions { get; set; }

        public bool IsSuccess => !Exceptions.Any();

        public string TraceId { get; set; } = string.Empty;
    }
}
