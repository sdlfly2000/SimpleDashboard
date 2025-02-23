using Application.UserRequirement;
using Common.Core.DependencyInjection;
using Domain.Services.UserStory.Repositories;
using Domain.User;
using Domain.UserRequirement;
using SimpleDashboard.Common;

namespace Application.Services.UserRequirement
{
    [ServiceLocate(typeof(IUserRequirementService))]
    public class UserRequirementService : IUserRequirementService
    {
        private IUserRequirementRepository _userRequirementRepository;
        private CurrentContext _context;

        public UserRequirementService(
            IUserRequirementRepository repository,
            CurrentContext context)
        {
            _userRequirementRepository = repository;
            _context = context;
        }

        public async Task<AssignUserStoryResponse> AssignUserStory(AssignUserStoryRequest request)
        {
            var response = new AssignUserStoryResponse();  

            try
            {
                await _userRequirementRepository.AssignUserStory(request.UserRequirementId, request.UserStoryId).ConfigureAwait(false);
            }
            catch (Exception ex) 
            {
                response.Exceptions.Add(ex);
            }

            return response;
        }

        public async Task<CreateUserRequirementResponse> Create(CreateUserRequirementRequest request)
        {
            var userRequirement = MapToEntity(
                request,
                UserRequirementEntity.Create(UserReference.Parse(_context.User)));
                 
            var usrRequirementId = await _userRequirementRepository.Add(userRequirement);

            return new CreateUserRequirementResponse
            {
                UserRequirementId = usrRequirementId
            };
        }

        #region Private Methods

        private UserRequirementEntity MapToEntity(CreateUserRequirementRequest request, UserRequirementEntity entity)
        {
            entity.Title = request.Title;
            entity.Description = request.Description;

            return entity;

        }

        #endregion
    }
}
