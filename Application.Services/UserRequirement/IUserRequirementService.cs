using Application.UserRequirement;
using System.ComponentModel;

namespace Application.Services.UserRequirement
{
    public interface IUserRequirementService
    {
        Task<CreateUserRequirementResponse> Create(CreateUserRequirementRequest request);

        Task<AssignUserStoryResponse> AssignUserStory(AssignUserStoryRequest request);
    }
}
