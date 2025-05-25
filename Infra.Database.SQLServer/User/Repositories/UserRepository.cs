using Common.Core.DependencyInjection;
using Domain.Services.Users.Reposiotries;
using Domain.User;
using Infra.Database.SQLServer.User.Entities;

namespace Infra.Database.SQLServer.User.Repositories
{
    [ServiceLocate(typeof(IUserRepository), ServiceType.Scoped)]
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _context;

        public UserRepository(UserDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Add(UserDomain aspect)
        {
            _context.UserEntities.Add(new UserEntity
            {
                Id = aspect.Id.Code,
                Name = aspect.Name
            });

            await _context.SaveChangesAsync();

            return Guid.Parse(aspect.Id.Code);
        }

        public Task<UserDomain> LoadById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task Update(UserDomain aspect)
        {
            throw new NotImplementedException();
        }
    }
}
