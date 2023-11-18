using SimpleDashboard.Common;

namespace Domain.User
{
    public class UserReference : Reference
    {
        public UserReference(string code) : base(code, CacheField.User)
        {
        }

        public static UserReference Parse(string code)
        {
            return new UserReference(code);
        }
    }
}
