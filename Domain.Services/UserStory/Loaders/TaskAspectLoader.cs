using Common.Core.DependencyInjection;
using Domain.Services.UserStory.Repositories;
using Domain.UserRequirement;

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

        public async Task<TaskAspect> LoadById(TaskReference id)
        {
            return await _taskRepository.LoadById(long.Parse(id.Code)).ConfigureAwait(false);
        }

        public async Task<List<TaskAspect>> LoadByUserStroyId(UserStoryReference id)
        {
            return await _taskRepository.LoadByUserStoryId(id).ConfigureAwait(false);
        }
    }
}
