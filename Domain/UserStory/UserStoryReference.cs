using Common.Core.AOP.Cache;
using SimpleDashboard.Common;

namespace Domain.UserStory
{
    public class UserStoryReference : IReference
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

        public UserStoryReference(string code, string? fieldName = null)
        {
            Code = code;
            CacheFieldName = fieldName ?? CacheField.UserStory;
        }

        public override bool Equals(object? obj)
        {
            return Code.Equals(((UserStoryReference)obj!).Code);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
