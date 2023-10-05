using Domain.Services.UserStory.Repositories;
using Microsoft.Extensions.DependencyInjection;
using SimpleDashboard;

namespace Infra.Database.MySQL.Test.UserStory
{
    [TestClass]
    public class UserStoryRepositoryTest
    {
        [TestInitialize]
        public void TestInitialize()
        {
            
        }

        [TestMethod, TestCategory("SystemTest")]
        public void LoadDataFromDB()
        {
            string[] args = { "%LAUNCHER_ARGS%" };

            // Arrange
            var host = Program.CreateHostBuilder(args).Build();
            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;

                // Act
                var userStoryRepository = services.GetRequiredService<IUserStoryRepository>();
                var userStory = userStoryRepository.LoadById(Guid.Parse("df9949a0-638e-11ee-a670-00262da8807c"));

                // Assert
                Assert.IsNotNull(userStoryRepository);
            }
        }
    }
}
