using Application.UserRequirement;

namespace Application.Services.UserRequirement
{
    public interface IUserRequirementService
    {
        Task<CreateUserRequirementResponse> Create(CreateUserRequirementRequest request);

        Task<AssignUserStoryResponse> AssignUserStory(AssignUserStoryRequest request);
    }
}
