using Common.Core.Data.Sql;
using Infra.Database.MySQL.User.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infra.Database.MySQL.UserStory.Entities
{
    public class UserStoryInformationEntity : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        [ForeignKey(nameof(Owner))]
        public Guid OwnerId { get; set; }

        public UserEntity Owner { get; set; }

        public DateTime StartedOn { get; set; }

        public TimeSpan Period { get; set; }

        public string Status { get; set; }

        public DateTime ModifiedOn { get; set; }

        [ForeignKey(nameof(ModifiedBy))]
        public Guid ModifiedById { get; set; }
        public UserEntity ModifiedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        [ForeignKey(nameof(CreatedBy))]
        public Guid CreatedById { get; set; }
        public UserEntity CreatedBy { get; set; }
    }
}
