using Domain.Services.UserStory.Repositories;
using Domain.UserStory;
using Microsoft.Extensions.DependencyInjection;
using SimpleDashboard;
using SimpleDashboard.Common;

namespace Infra.Database.MySQL.Test.UserStory.Repositories
{
    [TestClass]
    public class TaskRepositoryTest
    {
        [TestInitialize]
        public void TestInitialize()
        {

        }

        [TestMethod, TestCategory(nameof(TestCategoryEnum.SystemTest))]
        public void Given_UserStoryId_When_LoadTask_Then_TaskAspect_Return()
        {
            string[] args = Array.Empty<string>();

            // Arrange
            var host = Program.CreateHostBuilder(args).Build();
            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                var userStoryReference = new UserStoryReference("df9949a0-638e-11ee-a670-00262da8807c");
                var taskRepository = services.GetRequiredService<ITaskRepository>();

                // Act
                var tasks = taskRepository.LoadByUserStoryId(userStoryReference);

                // Assert
                Assert.IsNotNull(tasks);
            }
        }

    }
}
