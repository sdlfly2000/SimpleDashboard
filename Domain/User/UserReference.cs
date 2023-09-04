using Common.Core.AOP.Cache;
using SimpleDashboard.Common;

namespace Domain.User
{
    public class UserReference : IReference
    {
        public string Code { get; set; }
        public string CacheFieldName { get; set; }

        public string CacheCode
        {
            get
            {
                return CacheFieldName.Equals(string.Empty)
                            ? string.Empty
                            : string.Concat(CacheFieldName, Code);
            }
        }

        public UserReference(string code, string? fieldName = null)
        {
            Code = code;
            CacheFieldName = fieldName ?? CacheField.User;
        }

        public override bool Equals(object? obj)
        {
            return Code.Equals(((UserReference)obj!).Code);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
