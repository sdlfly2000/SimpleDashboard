using Common.Core.Data.Sql;
using Infra.Database.MySQL.User.Entities;

namespace Infra.Database.MySQL.UserStory.Entities
{
    public class TaskEntity : IEntity
    {
        public Guid Id { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public Guid? OwnerId { get; set; }

        public DateTime? StartedOn { get; set; }

        public TimeSpan? Period { get; set; }

        public string? Status { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public Guid? ModifiedById { get; set; }

        public DateTime? CreatedOn { get; set; }

        public Guid? CreatedById { get; set; }

        public Guid UserStoryId { get; set; }

        #region Navigations

        public UserStoryInformationEntity? UserStoryInformationEntity { get; set; }
        public UserEntity? Owner { get; set; }
        public UserEntity? CreatedBy { get; set; }
        public UserEntity? ModifiedBy { get; set; }

        #endregion
    }
}
