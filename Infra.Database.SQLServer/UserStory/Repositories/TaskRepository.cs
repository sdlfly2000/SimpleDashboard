using Common.Core.DependencyInjection;
using Domain.Services.UserStory.Repositories;
using Domain.UserRequirement;
using Infra.Database.SQLServer.UserStory.Context;
using Infra.Database.SQLServer.UserStory.Mappers;
using Infra.Database.SQLServer.UserStory.Synchronizers;
using Microsoft.EntityFrameworkCore;
using SimpleDashboard.Common.Exceptions;
using Task = Infra.Database.SQLServer.UserStory.Entities.Task;

namespace Infra.Database.SQLServer.UserStory.Repositories
{
    [ServiceLocate(typeof(ITaskRepository))]
    public class TaskRepository : ITaskRepository
    {
        private readonly UserStoryDbContext _context;
        private readonly ITaskAspectMapper _mapper;
        private readonly ITaskAspectSynchronizer _synchronizer;

        public TaskRepository(
            UserStoryDbContext context, 
            ITaskAspectMapper mapper,
            ITaskAspectSynchronizer synchronizer)
        {
            _context = context;
            _mapper = mapper;
            _synchronizer = synchronizer;
        }

        public async Task<TaskEntity> LoadById(long id)
        {
            var task = await _context.Set<Task>().FindAsync(id).ConfigureAwait(false);

            if (task == null) 
            {
                throw new NotFoundFromDatabaseException<Task>(id.ToString());
            }

            return _mapper.Map(task);          
        }

        public async Task<List<TaskEntity>> LoadByUserStoryId(UserStoryReference userStoryId)
        {
            var userStoryGuid = long.Parse(userStoryId.Code);
            return await _context.Set<Task>()
               .Where(entity => entity.UserStoryId.Equals(userStoryGuid))
               .Select(entity => _mapper.Map(entity))
               .ToListAsync()
               .ConfigureAwait(false);
        }

        public async System.Threading.Tasks.Task Update(TaskEntity aspect)
        {
            var task = await _synchronizer.Synchronize(aspect).ConfigureAwait(false);
            var taskUpdated = _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
        }

        public async Task<long> Add(TaskEntity aspect)
        {
            var task = await _synchronizer.Synchronize(aspect).ConfigureAwait(false);
            var taskAdded = await _context.Tasks.AddAsync(task).ConfigureAwait(false);
            await _context.SaveChangesAsync();
            return taskAdded.Entity.Id;
        }
    }
}
