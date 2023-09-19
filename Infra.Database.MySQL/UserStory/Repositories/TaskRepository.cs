using Common.Core.DependencyInjection;
using Domain.Services.UserStory.Repositories;
using Domain.UserStory;
using Infra.Database.MySQL.UserStory.Entities;
using Infra.Database.MySQL.UserStory.Mappers;

namespace Infra.Database.MySQL.UserStory.Repositories
{
    [ServiceLocate(typeof(ITaskRepository))]
    public class TaskRepository : ITaskRepository
    {
        private readonly SimpleDashboardContext _context;
        private readonly ITaskAspectMapper _mapper;

        public TaskRepository(SimpleDashboardContext context, ITaskAspectMapper mapper )
        {
            _context = context;
            _mapper = mapper;
        }

        public ITaskAspect LoadById(TaskReference id)
        {
            return _mapper.Map(_context.Set<TaskEntity>().Find(id));
        }

        public List<ITaskAspect> LoadByUserStoryId(UserStoryReference userStoryId)
        {
            var userStoryGuid = Guid.Parse(userStoryId.Code);
            return _context.Set<TaskEntity>()
               .Where(entity => entity.UserStoryId.Equals(userStoryGuid))
               .Select(entity => _mapper.Map(entity))
               .ToList();
        }
    }
}
