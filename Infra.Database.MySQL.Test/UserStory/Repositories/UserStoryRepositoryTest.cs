using Domain.Services.UserStory.Repositories;
using Domain.User;
using Domain.UserStory;
using Microsoft.Extensions.DependencyInjection;
using SimpleDashboard;
using SimpleDashboard.Common;

namespace Infra.Database.MySQL.Test.UserStory.Repositories
{
    [TestClass]
    public class UserStoryRepositoryTest
    {
        [TestInitialize]
        public void TestInitialize()
        {

        }

        [TestMethod, TestCategory(nameof(TestCategoryEnum.SystemTest))]
        public void Given_UserStoryId_When_LoadById_Then_UserStroyInformationAspect_Return()
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

        [TestMethod, TestCategory(nameof(TestCategoryEnum.SystemTest))]
        public void Given_Aspect_When_Add_Then_UserStroyId_Return()
        {
            string[] args = Array.Empty<string>();

            // Arrange
            var host = Program.CreateHostBuilder(args).Build();
            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                var userStoryId = Guid.NewGuid();
                var reference = new UserStoryReference(userStoryId.ToString());
                var aspect = new UserStoryInformationAspect(reference)
                {                    
                    Title = "Title",
                    Description = "Description",
                    Owner = new UserReference("6e0ddf4a-638e-11ee-a670-00262da8807c"),
                    CreatedBy = new UserReference("6e0ddf4a-638e-11ee-a670-00262da8807c"),
                    ModifiedBy = new UserReference("6e0ddf4a-638e-11ee-a670-00262da8807c")
                };

                // Act
                var userStoryRepository = services.GetRequiredService<IUserStoryRepository>();
                var userStoryIdReturn = userStoryRepository.Add(aspect);

                // Assert
                Assert.IsNotNull(userStoryIdReturn);
                Assert.AreEqual(userStoryId, userStoryIdReturn);
            }
        }
    }
}
