using Common.Core.DependencyInjection;
using Domain.Services.UserStory.Repositories;
using Domain.UserStory;
using Infra.Database.MySQL.UserStory.Entities;
using Infra.Database.MySQL.UserStory.Mappers;

namespace Infra.Database.MySQL.UserStory.Repositories
{
    [ServiceLocate(typeof(IUserStoryRepository))]
    public class UserStoryRepository : IUserStoryRepository
    {
        private readonly SimpleDashboardContext _context;
        private readonly IUserStoryInformationAspectMapper _mapper;

        public UserStoryRepository(IUserStoryInformationAspectMapper mapper, SimpleDashboardContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public IUserStoryInformationAspect LoadById(Guid Id)
        {
            return _mapper.Map(_context.Set<UserStoryInformationEntity>().Find(Id));
        }
    }
}