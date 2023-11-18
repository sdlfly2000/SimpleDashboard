using Domain.Services.UserStory.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleDashboard.Common;
using SimpleDashboard.Extentions;

namespace Infra.Database.MySQL.Test.UserStory.Repositories
{
    [TestClass]
    public class TaskRepositoryTest
    {
        [TestInitialize]
        public void TestInitialize()
        {

        }

        [TestMethod, TestCategory(nameof(TestCategoryEnum.UnitTest))]
        public void Given_UserStoryId_When_LoadTask_Then_TaskAspect_Return()
        {
            string[] args = Array.Empty<string>();

            // Arrange
            var serviceContainer = ServiceContainer.CreateDefaultForUnitTest();
            using (var serviceScope = serviceContainer.BuildServiceProvider())
            {
                // Act
                var taskRepository = serviceScope.GetRequiredService<ITaskRepository>();

                // Assert
                Assert.IsNotNull(taskRepository);
            }
        }
    }
}
