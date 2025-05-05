using Application.Services.UserRequirement;
using Application.UserRequirement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Presentation.Web.Api.models;

namespace Presentation.Web.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [EnableCors("AllowPolicy")]
    [Authorize]
    public class UserRequirementController : ControllerBase
    {
        private readonly IUserRequirementService _userRequirementService;

        public UserRequirementController(IUserRequirementService userRequirementService)
        {
            _userRequirementService = userRequirementService;
        }

        [HttpPost]
        public async Task<IActionResult> NewRequirement([FromBody] CreateUserRequirementRequestModel model)
        {
            var response = await _userRequirementService.Create(new CreateUserRequirementRequest
            {
                Title = model.Title,
                Description = model.Description
            });

            Response.Headers.Append("Activator-SimpleDashboard-TraceId", response.TraceId);
            return response.IsSuccess
                ? Ok()
                : Problem(string.Join<Exception>(',', response.Exceptions.ToArray()));
        }
    }
}