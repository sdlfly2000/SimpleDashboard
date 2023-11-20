using Domain.Services.UserStory.Repositories;
using Domain.UserStory;
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
        public void Get_TaskRepository_Service()
        {
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

        [TestMethod, TestCategory(nameof(TestCategoryEnum.SystemTest))]
        public void Given_UserStoryId_When_LoadTask_Then_TaskAspect_Return()
        {
            // Arrange
            var serviceContainer = ServiceContainer.CreateDefaultForUnitTest();
            using (var serviceScope = serviceContainer.BuildServiceProvider())
            {
                var taskRepository = serviceScope.GetRequiredService<ITaskRepository>();
                var reference = new TaskReference("a0210fc2-6b2f-11ee-bd08-00262da8807c");

                // Action
                var task = taskRepository.LoadById(reference);

                // Assert
                Assert.IsNotNull(task);
            }
        }
    }
}
