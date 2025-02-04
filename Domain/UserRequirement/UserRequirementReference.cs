using SimpleDashboard.Common;

namespace Domain.UserRequirement
{
    public class UserRequirementReference : Reference
    {
        public UserRequirementReference(long code) : base(code.ToString(), CacheField.UserRequirement)
        {
        }
    }
}
