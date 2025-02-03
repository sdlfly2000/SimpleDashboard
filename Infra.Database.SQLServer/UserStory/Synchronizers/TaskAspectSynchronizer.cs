using Common.Core.DependencyInjection;
using Domain.UserRequirement;
using Infra.Database.SQLServer.UserStory.Context;
using Infra.Database.SQLServer.UserStory.Entities;
using SimpleDashboard.Common.Exceptions;
using Task = Infra.Database.SQLServer.UserStory.Entities.Task;

namespace Infra.Database.SQLServer.UserStory.Synchronizers;

[ServiceLocate(typeof(ITaskAspectSynchronizer))]
public class TaskAspectSynchronizer : ITaskAspectSynchronizer
{
    private readonly UserStoryDbContext _context;

    public TaskAspectSynchronizer(UserStoryDbContext context)
    {
        _context = context;
    }

    public async System.Threading.Tasks.Task<Task> Synchronize(ITaskAspect aspect)
    {
        if (aspect.Reference is null)
        {
            return new Task
            {
                Title = aspect.Title,
                Description = aspect.Description,
                OwnerId = aspect.Owner.Code,
                StartedOn = aspect.StartedOn,
                Status = aspect.Status.Status,
                ModifiedOn = aspect.ModifiedOn,
                ModifiedById = aspect.ModifiedBy.Code,
                CreatedOn = aspect.CreatedOn,
                CreatedById = aspect.CreatedBy.Code,
                Period = aspect.Period.Ticks
            };
        }

        return await Update(aspect);        
    }

    private async System.Threading.Tasks.Task<Task> Update(ITaskAspect aspect)
    {
        var task = await _context.Tasks.FindAsync(long.Parse(aspect.Reference.Code)).ConfigureAwait(false);

        if (task == null)
        {
            throw new NotFoundFromDatabaseException<UserStoryInformation>(aspect.Reference.Code);
        }

        task.Title = aspect.Title;
        task.Description = aspect.Description;
        task.OwnerId = aspect.Owner.Code;
        task.StartedOn = aspect.StartedOn;
        task.Status = aspect.Status.Status;
        task.ModifiedOn = aspect.ModifiedOn;
        task.ModifiedById = aspect.ModifiedBy.Code;
        task.CreatedOn = aspect.CreatedOn;
        task.CreatedById = aspect.CreatedBy.Code;
        task.Period = aspect.Period.Ticks;

        return task;
    }
}
