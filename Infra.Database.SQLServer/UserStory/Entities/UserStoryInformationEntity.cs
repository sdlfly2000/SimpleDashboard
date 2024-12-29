using Common.Core.Data.Sql;
using Infra.Database.SQLServer.User.Entities;

namespace Infra.Database.SQLServer.UserStory.Entities
{
    public class UserStoryInformationEntity : IEntity
    {
        public Guid Id { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public Guid OwnerId { get; set; }
        public UserEntity? Owner { get; set; }

        public DateTime? StartedOn { get; set; }

        public TimeSpan? Period { get; set; }

        public string? Status { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public Guid ModifiedById { get; set; }
        public UserEntity ModifiedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public Guid CreatedById { get; set; }
        public UserEntity CreatedBy { get; set; }
    }
}
