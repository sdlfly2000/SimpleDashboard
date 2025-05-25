using Domain.User;

namespace Domain.Services.Users.Reposiotries
{
    public interface IUserRepository : IRepository<Guid, UserDomain>
    {        
    }
}
