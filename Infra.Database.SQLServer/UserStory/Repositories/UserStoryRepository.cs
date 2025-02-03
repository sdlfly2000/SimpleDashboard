using Common.Core.DependencyInjection;
using Domain.Services;
using Domain.Services.UserStory.Repositories;
using Domain.UserRequirement;
using Infra.Database.SQLServer.UserStory.Context;
using Infra.Database.SQLServer.UserStory.Entities;
using Infra.Database.SQLServer.UserStory.Mappers;
using Infra.Database.SQLServer.UserStory.Synchronizers;
using Microsoft.EntityFrameworkCore;
using SimpleDashboard.Common.Exceptions;
using Task = System.Threading.Tasks.Task;

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

        public async Task<long> Add(UserStoryInformationAspect aspect)
        {
            var entity = await _synchronizer.Synchronize(aspect);
            var entityAdded = await _context.UserStoryInformations.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entityAdded.Entity.Id;
        }

        public async Task Update(UserStoryInformationAspect aspect)
        {
            var entity = await _synchronizer.Synchronize(aspect);
            _context.UserStoryInformations.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<UserStoryInformationAspect> LoadById(long Id)
        {
            var entity = await _context.Set<UserStoryInformation>()
                .SingleOrDefaultAsync(ent => ent.Id.Equals(Id))
                .ConfigureAwait(false);

            if(entity is null)
            {
                throw new NotFoundFromDatabaseException<UserStoryInformation>(Id.ToString());
            }

            return _mapper.Map(entity);
        }

        public async Task<IList<UserStoryInformationAspect>> LoadByOwnerId(Guid id)
        {
            var userStotryInformations = await _context.Set<UserStoryInformation>()
                .Where(entity => !string.IsNullOrEmpty(entity.OwnerId) && entity.OwnerId.Equals(id))
                .ToListAsync()
                .ConfigureAwait(false);

            return userStotryInformations.Select(_mapper.Map).ToList();
        }
    }
}