using Common.Core.AOP.Cache;
using Common.Core.DependencyInjection;
using Domain.Services.UserStory.Repositories;
using Domain.UserStory;
using Infra.Database.MySQL.UserStory.Entities;
using Infra.Database.MySQL.UserStory.Mappers;
using Infra.Database.MySQL.UserStory.Synchronizers;

namespace Infra.Database.MySQL.UserStory.Repositories
{
    [ServiceLocate(typeof(IUserStoryRepository))]
    public class UserStoryRepository : IUserStoryRepository
    {
        private readonly SimpleDashboardContext _context;
        private readonly IUserStoryInformationAspectMapper _mapper;
        private readonly IUserStoryInformationAspectSynchronizer _synchronizer;

        public UserStoryRepository(
            IUserStoryInformationAspectMapper mapper, 
            IUserStoryInformationAspectSynchronizer synchronizer,
            SimpleDashboardContext context)
        {
            _mapper = mapper;
            _synchronizer = synchronizer;
            _context = context;
        }

        public IReference Add(IUserStoryInformationAspect aspect)
        {
            throw new NotImplementedException();
        }

        public void Update(IUserStoryInformationAspect aspect)
        {
            throw new NotImplementedException();
        }

        public IUserStoryInformationAspect LoadById(Guid Id)
        {
            return _mapper.Map(_context.Set<UserStoryInformationEntity>().Find(Id));
        }
    }
}