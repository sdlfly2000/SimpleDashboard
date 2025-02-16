using SimpleDashboard.Common;

namespace Domain.User
{
    public class UserReference : Reference
    {
        public UserReference(Guid code) : base(code.ToString(), CacheField.User)
        {
        }

        public static UserReference Parse(Guid code)
        {
            if (code == null)
            {
                return default;
            }

            return new UserReference(code);
        }

        public static explicit operator UserReference(Guid code)
        {
            return Parse(code);
        }

        public static explicit operator UserReference(string code)
        {
            if(Guid.TryParse(code, out var guidCode))
            {
                return Parse(guidCode);
            }
            else
            {
                return default;
            }
        }
    }
}
