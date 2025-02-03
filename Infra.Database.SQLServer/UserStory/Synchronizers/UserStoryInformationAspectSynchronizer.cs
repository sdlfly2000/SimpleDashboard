using Common.Core.DependencyInjection;
using Domain.UserRequirement;
using Infra.Database.SQLServer.UserStory.Context;
using Infra.Database.SQLServer.UserStory.Entities;
using SimpleDashboard.Common.Exceptions;

namespace Infra.Database.SQLServer.UserStory.Synchronizers;

[ServiceLocate(typeof(IUserStoryInformationAspectSynchronizer))]
public class UserStoryInformationAspectSynchronizer : IUserStoryInformationAspectSynchronizer
{
    private readonly UserStoryDbContext _context;

    public UserStoryInformationAspectSynchronizer(UserStoryDbContext context)
    {
        _context = context;
    }

    public async Task<UserStoryInformation> Synchronize(IUserStoryInformationAspect aspect)
    {
        if (aspect.Reference is null)
        {
            return new UserStoryInformation
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

    private async Task<UserStoryInformation> Update(IUserStoryInformationAspect aspect)
    {
        var userStoryInformation = await _context.UserStoryInformations.FindAsync(long.Parse(aspect.Reference.Code)).ConfigureAwait(false);

        if (userStoryInformation == null)
        {
            throw new NotFoundFromDatabaseException<UserStoryInformation>(aspect.Reference.Code);
        }

        userStoryInformation.Title = aspect.Title;
        userStoryInformation.Description = aspect.Description;
        userStoryInformation.OwnerId = aspect.Owner.Code;
        userStoryInformation.StartedOn = aspect.StartedOn;
        userStoryInformation.Status = aspect.Status.Status;
        userStoryInformation.ModifiedOn = aspect.ModifiedOn;
        userStoryInformation.ModifiedById = aspect.ModifiedBy.Code;
        userStoryInformation.CreatedOn = aspect.CreatedOn;
        userStoryInformation.CreatedById = aspect.CreatedBy.Code;
        userStoryInformation.Period = aspect.Period.Ticks;

        return userStoryInformation;
    }
}
