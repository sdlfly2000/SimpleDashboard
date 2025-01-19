using Common.Core.DependencyInjection;
using Domain.Services.UserStory.Repositories;
using Domain.UserStory;

namespace Domain.Services.UserStory.Loaders
{
    [ServiceLocate(typeof(ITaskAspectLoader))]
    public class TaskAspectLoader : ITaskAspectLoader
    {
        private readonly ITaskRepository _taskRepository;

        public TaskAspectLoader(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<ITaskAspect> LoadById(TaskReference id)
        {
            return await _taskRepository.LoadById(id).ConfigureAwait(false);
        }

        public async Task<List<ITaskAspect>> LoadByUserStroyId(UserStoryReference id)
        {
            return await _taskRepository.LoadByUserStoryId(id).ConfigureAwait(false);
        }
    }
}
