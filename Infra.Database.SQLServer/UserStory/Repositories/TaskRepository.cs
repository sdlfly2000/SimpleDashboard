using Common.Core.DependencyInjection;
using Domain.Services.UserStory.Repositories;
using Domain.UserStory;
using Infra.Database.SQLServer.UserStory.Context;
using Infra.Database.SQLServer.UserStory.Mappers;
using Microsoft.EntityFrameworkCore;
using Task = Infra.Database.SQLServer.UserStory.Entities.Task;

namespace Infra.Database.SQLServer.UserStory.Repositories
{
    [ServiceLocate(typeof(ITaskRepository))]
    public class TaskRepository : ITaskRepository
    {
        private readonly UserStoryDbContext _context;
        private readonly ITaskAspectMapper _mapper;

        public TaskRepository(UserStoryDbContext context, ITaskAspectMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ITaskAspect> LoadById(TaskReference id)
        {
            var task = await _context.Set<Task>().FindAsync(long.Parse(id.Code)).ConfigureAwait(false);
            if (task == null) 
            {
                throw new Exception($"Not find Task with Id: {id.Code}");
            }

            return _mapper.Map(task);          
        }

        public async Task<List<ITaskAspect>> LoadByUserStoryId(UserStoryReference userStoryId)
        {
            var userStoryGuid = long.Parse(userStoryId.Code);
            return await _context.Set<Task>()
               .Where(entity => entity.UserStoryId.Equals(userStoryGuid))
               .Select(entity => _mapper.Map(entity))
               .ToListAsync()
               .ConfigureAwait(false);
        }
    }
}
