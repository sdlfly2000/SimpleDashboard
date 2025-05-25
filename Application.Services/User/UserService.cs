using Application.User;
using Common.Core.DependencyInjection;
using Domain.Services.Users.Reposiotries;
using Domain.User;
using SimpleDashboard.Common;
using SimpleDashboard.Common.Interceptors;
using SimpleDashboard.Common.Metric;

namespace Application.Services.User
{
    [ServiceLocate(default, ServiceType.Scoped)]
    public class UserService : BaseObject
    {
        private readonly IUserRepository _userRepository;

        public UserService(
            IUserRepository userRepository,
            IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _userRepository = userRepository;
        }

        [LogTrace(EnumMetricMeasure.AppRegisterUser)]
        public async Task<UserRegisterResponse> Register(UserRegisterRequest request)
        {
            var response =  new UserRegisterResponse();
            var user = new UserDomain
            {
                Id = UserReference.Parse(request.UserId),
                Name = request.Name
            };

            try
            {
                var userId = await _userRepository.Add(user);
            }
            catch(Exception e)
            {
                response.Exceptions.Add(e);
            }

            return response;
        }
    }
}
