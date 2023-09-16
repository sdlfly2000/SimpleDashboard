using System.ComponentModel.DataAnnotations;

namespace Infra.Database.MySQL.User.Entities
{
    public class UserEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
