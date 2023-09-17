using Common.Core.Data.Sql;
using Infra.Database.MySQL.User.Entities;
using System.ComponentModel.DataAnnotations;

namespace Infra.Database.MySQL.UserStory.Entities
{
    public class UserStoryInformationEntity : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public UserEntity Owner { get; set; }

        public DateTime StartedOn { get; set; }

        public TimeSpan Period { get; set; }

        public string Status { get; set; }

        public DateTime ModifiedOn { get; set; }

        public UserEntity ModifiedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public UserEntity CreatedBy { get; set; }
    }
}
