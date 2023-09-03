using System.ComponentModel.DataAnnotations;

namespace Infra.Database.MySQL.UserStory.Entities
{
    public class UserStoryInformationEntity
    {
        [Key]
        public Guid Id { get; set; }
        
        public string Title { get; set; }

        public string Description { get; set; }

        public Guid Owner { get; set; }

        public DateTime StartedOn { get; set; }

        public TimeSpan Period { get; set; }
    }
}
