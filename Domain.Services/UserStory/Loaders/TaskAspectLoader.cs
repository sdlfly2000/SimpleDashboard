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

        public ITaskAspect LoadById(TaskReference id)
        {
            return _taskRepository.LoadById(id);
        }

        public IList<ITaskAspect> LoadByUserStroyId(UserStoryReference id)
        {
            return _taskRepository.LoadByUserStoryId(id);
        }
    }
}
