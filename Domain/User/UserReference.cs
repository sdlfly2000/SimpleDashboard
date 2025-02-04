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
            if (string.IsNullOrEmpty(code))
            {
                return default;
            }

            return new UserReference(code);
        }
    }
}
