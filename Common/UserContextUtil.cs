namespace SimpleDashboard.Common
{
    public class UserContextUtil
    {
        public static Guid GetCurrentUserId(string JWTCachedKey)
        {
            return Guid.Parse(JWTCachedKey.Split('|')[0]);
        }
    }
}
