using Common.Core.DependencyInjection;
using Domain.Services.UserStory.Repositories;
using Domain.User;
using Domain.UserRequirement;
using Infra.Database.SQLServer.UserStory.Context;
using Infra.Database.SQLServer.UserStory.Entities;
using Microsoft.EntityFrameworkCore;
using SimpleDashboard.Common.Exceptions;
using Task = System.Threading.Tasks.Task;

namespace Infra.Database.SQLServer.UserStory.Repositories
{
    [ServiceLocate(typeof(IUserRequirementRepository))]
    public class UserRequirementRepository : IUserRequirementRepository
    {
        private readonly UserStoryDbContext _context;

        public UserRequirementRepository(
            UserStoryDbContext context)
        {
            _context = context;
        }

        public async Task<UserRequirementEntity> LoadById(long Id)
        {
            var userRequirement = await _context.UserRequirements.FindAsync(Id).ConfigureAwait(false);
            if(userRequirement is null)
            {
                throw new NotFoundFromDatabaseException<UserRequirementEntity>(Id.ToString());
            }

            return Map(userRequirement);
        }

        public async Task<IList<UserRequirementEntity>> LoadByOwnerId(Guid id)
        {
            var userRequirements = await _context.UserRequirements
                .Where(r => r.OwnerId.Equals(id.ToString()))
                .ToListAsync()
                .ConfigureAwait(false);

            return userRequirements
                .Select(Map)
                .ToList();
        }

        public async Task Update(UserRequirementEntity aspect)
        {
            var userRequirement = Synchronize(aspect);
            var entry = await _context.UserRequirements.AddAsync(userRequirement).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<long> Add(UserRequirementEntity aspect)
        {
            var userRequirement = Synchronize(aspect);
            var entry = await _context.UserRequirements.AddAsync(userRequirement).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return entry.Entity.Id;
        }


        #region Private Methods

        private UserRequirement Synchronize(UserRequirementEntity entity)
        {
            var userRequirement = new UserRequirement
            {
                Title = entity.Title,
                Description = entity.Description,
                CreatedById = entity.CreatedBy.Code,
                CreatedOn = entity.CreatedOn,
                ModifiedById = entity.ModifiedBy.Code,
                ModifiedOn = entity.ModifiedOn,
                OwnerId = entity.Owner.Code,
                StartedOn = entity.StartedOn,
                Status = entity.Status.ToString()
            };

            if (entity.Reference is null)
            {
                return userRequirement;
            }

            userRequirement.Id = long.Parse(entity.Reference.Code);

            return userRequirement;
        }

        private UserRequirementEntity Map(UserRequirement userRequirement)
        {
            return new UserRequirementEntity
            {
                Title = userRequirement.Title,
                Description = userRequirement.Description,
                CreatedBy = UserReference.Parse(Guid.Parse(userRequirement.CreatedById)),
                CreatedOn = userRequirement.CreatedOn.HasValue ? userRequirement.CreatedOn.Value : default,
                ModifiedBy = UserReference.Parse(Guid.Parse(userRequirement.ModifiedById)),
                ModifiedOn = userRequirement.ModifiedOn.HasValue ? userRequirement.ModifiedOn.Value : default,
                Owner = UserReference.Parse(Guid.Parse(userRequirement.OwnerId)),
                StartedOn = userRequirement.StartedOn.HasValue ? userRequirement.StartedOn.Value : default,
                Status = Enum.Parse<EnumRecordStatus>(userRequirement.Status)
            };
        }

        #endregion
    }
}