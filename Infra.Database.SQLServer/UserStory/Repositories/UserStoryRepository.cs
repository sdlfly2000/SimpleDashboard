using Common.Core.DependencyInjection;
using Domain.Services.UserStory.Repositories;
using Domain.Services.UserStory.Synchronizers;
using Domain.UserStory;
using Infra.Database.SQLServer;
using Infra.Database.SQLServer.UserStory.Entities;
using Infra.Database.SQLServer.UserStory.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Infra.Database.SQLServer.UserStory.Repositories
{
    [ServiceLocate(typeof(IUserStoryRepository))]
    public class UserStoryRepository : IUserStoryRepository
    {
        private readonly UserStoryDbContext _context;
        private readonly IUserStoryInformationAspectMapper _mapper;
        private readonly IUserStoryInformationAspectSynchronizer _synchronizer;

        public UserStoryRepository(
            IUserStoryInformationAspectMapper mapper,
            IUserStoryInformationAspectSynchronizer synchronizer,
            UserStoryDbContext context)
        {
            _mapper = mapper;
            _synchronizer = synchronizer;
            _context = context;
        }

        public void Add(IUserStoryInformationAspect aspect)
        {
            var entity = (UserStoryInformation)_synchronizer.Synchronize(aspect);
            _context.UserStoryInformations.Add(entity);
            _context.SaveChanges();
        }

        public void Update(IUserStoryInformationAspect aspect)
        {
            var entity = (UserStoryInformation)_synchronizer.Synchronize(aspect);
            _context.UserStoryInformations.Update(entity);
            _context.SaveChanges();
        }

        public IUserStoryInformationAspect LoadById(Guid Id)
        {
            var entity = _context.Set<UserStoryInformation>()
                .Single(ent => ent.Id.Equals(Id));

            return _mapper.Map(entity);
        }

        public IList<IUserStoryInformationAspect> LoadByOwnerId(Guid id)
        {
            return _context
                .Set<UserStoryInformation>()
                .Where(entity => entity.OwnerId.Equals(id))
                .Select(_mapper.Map)
                .ToList();
        }
    }
}