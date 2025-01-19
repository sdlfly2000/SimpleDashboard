using Common.Core.Data.Sql;
using Domain.User;
using Domain.UserStory;
using FakeItEasy;
using FluentAssertions;
using Infra.Database.SQLServer.UserStory.Entities;
using Infra.Database.SQLServer.UserStory.Mappers;
using Infra.Database.SQLServer.UserStory.Repositories;
using MockQueryable.FakeItEasy;
using SimpleDashboard.Common;
using Task = System.Threading.Tasks.Task;

namespace Infra.Database.SQLServer.Test.UserStory.Repositories
{
    public class TaskRepositoryTest
    {
        private TaskRepository _testee;

        [SetUp]
        public void Setup()
        {
            var tasks = new List<SQLServer.UserStory.Entities.Task>
            { 
                new SQLServer.UserStory.Entities.Task
                {
                   Id = 1,
                   Title = "Test1",
                },
                new SQLServer.UserStory.Entities.Task
                {
                   Id = 2,
                },
            };

            var taskAspectMapper = A.Fake<ITaskAspectMapper>(o => o.Strict());
            var userStoryDbContext = A.Fake<UserStoryDbContext>();

            A.CallTo(() => userStoryDbContext.Set<SQLServer.UserStory.Entities.Task>()).Returns(tasks.AsQueryable().BuildMockDbSet());
            A.CallTo(() => taskAspectMapper.Map(A<SQLServer.UserStory.Entities.Task>._)).ReturnsLazily((SQLServer.UserStory.Entities.Task task) =>
            {
                return new TaskAspect
                {
                    Reference = new TaskReference(task.Id),
                    Title = task.Title ?? string.Empty,
                    Description = task.Description ?? string.Empty,
                    Owner = new UserReference(task.OwnerId?.ToString()),
                    StartedOn = task.StartedOn ?? default,
                    Period = task.Period.HasValue ? TimeSpan.FromTicks(task.Period.Value) : default,
                    Status = Domain.UserStory.TaskStatus.Parse(task.Status),
                    ModifiedOn = task.ModifiedOn ?? default,
                    ModifiedBy = new UserReference(task.ModifiedById?.ToString()),
                    CreatedOn = task.CreatedOn ?? default,
                    CreatedBy = new UserReference(task.CreatedById?.ToString())
                };
            });

            _testee = new TaskRepository(userStoryDbContext, taskAspectMapper);
        }

        [Test, Category(nameof(TestCategoryEnum.UnitTest))]
        public async Task Given_TaskReference_When_LoadById_Then_TaskAspect_return()
        {
            // Arrange
            var taskReference = new TaskReference(1);

            // Action
            var taskAspect = await _testee.LoadById(taskReference).ConfigureAwait(false);

            // Asserts
            taskAspect.Should().NotBeNull();
            taskAspect.Reference.Code.Should().Be("1");
            taskAspect.Title.Should().Be("Test1");
            
        }
    }
}