using Common.Core.DependencyInjection;
using Domain.Services.UserStory.Repositories;
using Domain.UserStory;
using Infra.Database.MySQL.UserStory.Entities;
using Infra.Database.MySQL.UserStory.Mappers;
using Infra.Database.MySQL.UserStory.Synchronizers;
using Microsoft.EntityFrameworkCore;

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

        public Guid Add(IUserStoryInformationAspect aspect)
        {
            var entity = (UserStoryInformationEntity)_synchronizer.Synchronize(aspect);
            _context.UserStoryInformationEntities.Add(entity);
            _context.SaveChanges();
            return entity.Id;
        }

        public void Update(IUserStoryInformationAspect aspect)
        {
            var entity = (UserStoryInformationEntity)_synchronizer.Synchronize(aspect);
            _context.UserStoryInformationEntities.Update(entity);
            _context.SaveChanges();
        }

        public IUserStoryInformationAspect LoadById(Guid Id)
        {
            var entity = _context.Set<UserStoryInformationEntity>()
                .Include(ent => ent.Owner)
                .Single(ent => ent.Id.Equals(Id));

            return _mapper.Map(entity);
        }

        public IList<IUserStoryInformationAspect> LoadByOwnerId(Guid id)
        {
            return _context
                .Set<UserStoryInformationEntity>()
                .Where(entity => entity.OwnerId.Equals(id))
                .Select(_mapper.Map)
                .ToList();
        }
    }
}