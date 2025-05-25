namespace Application.User
{
    public class UserRegisterResponse : IApplicationResponse
    {
        public UserRegisterResponse()
        {
            Exceptions = new List<Exception>();
        }

        public IList<Exception> Exceptions { get; set; }

        public bool IsSuccess => !Exceptions.Any();

        public string TraceId { get; set; } = string.Empty;
    }
}
