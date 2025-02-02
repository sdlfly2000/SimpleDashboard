using Domain.User;
using Domain.UserStory;
using FakeItEasy;
using FluentAssertions;
using Infra.Database.SQLServer.UserStory.Context;
using Infra.Database.SQLServer.UserStory.Mappers;
using Infra.Database.SQLServer.UserStory.Repositories;
using Infra.Database.SQLServer.UserStory.Synchronizers;
using SimpleDashboard.Common;
using Task = System.Threading.Tasks.Task;

namespace Infra.Database.SQLServer.Test.UserStory.Repositories
{
    public class TaskRepositoryTest
    {
        private TaskRepository _testee;
        private UserStoryDbContext _userStoryDbContext;

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
            var taskAspectSynchronizer = A.Fake<ITaskAspectSynchronizer>(o => o.Strict());
            _userStoryDbContext = DbContextFactory.CreateFake<UserStoryDbContext>();

            _userStoryDbContext.Tasks.AddRange(tasks);
            _userStoryDbContext.SaveChanges();

            A.CallTo(() => taskAspectMapper.Map(A<SQLServer.UserStory.Entities.Task>.Ignored)).ReturnsLazily((SQLServer.UserStory.Entities.Task task) =>
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

            _testee = new TaskRepository(_userStoryDbContext, taskAspectMapper, taskAspectSynchronizer);
        }

        [Test, Category(nameof(TestCategoryEnum.UnitTest))]
        public async Task Given_TaskReference_When_LoadById_Then_TaskAspect_return()
        {
            // Arrange
            var taskReference = new TaskReference(1);

            // Action
            var taskAspect = await _testee.LoadById(long.Parse(taskReference.Code)).ConfigureAwait(false);

            // Asserts
            taskAspect.Should().NotBeNull();
            taskAspect.Reference.Code.Should().Be("1");
            taskAspect.Title.Should().Be("Test1");
            
        }

        [Test, Category(nameof(TestCategoryEnum.SystemTest))]
        public async Task Given_Task_When_Add_Then_TaskAspect_SavedToWorkingDatabase()
        {
            // Arrange
            var taskAspect = new TaskAspect
            {
                Title = "Test1",
                Description = "Description1",
                Owner = new UserReference("1"),
                StartedOn = DateTime.Now,
                Period = TimeSpan.FromDays(1),
                Status = Domain.UserStory.TaskStatus.Initial,
                ModifiedOn = DateTime.Now,
                ModifiedBy = new UserReference("1"),
                CreatedOn = DateTime.Now,
                CreatedBy = new UserReference("1")
            };

            using var userStoryDbContext = DbContextFactory.Create<UserStoryDbContext>();
            var repository = new TaskRepository(userStoryDbContext, new TaskAspectMapper(), new TaskAspectSynchronizer(userStoryDbContext));

            // Action
            var taskId = await repository.Add(taskAspect).ConfigureAwait(false);

            // Asserts
            var task = await userStoryDbContext.Tasks.FindAsync(taskId).ConfigureAwait(false);
            task.Should().NotBeNull();
            task.Title.Should().Be("Test1");
            task.Description.Should().Be("Description1");
        }

        [Test, Category(nameof(TestCategoryEnum.SystemTest))]
        public async Task Given_TaskReference_When_LoadById_Then_TaskAspect_returnFromWorkingDatabase()
        {
            // Arrange
            var taskReference = new TaskReference(1);
            using var userStoryDbContext = DbContextFactory.Create<UserStoryDbContext>();
            var repository = new TaskRepository(userStoryDbContext, new TaskAspectMapper(), new TaskAspectSynchronizer(userStoryDbContext));

            // Action
            var taskAspect = await repository.LoadById(long.Parse(taskReference.Code)).ConfigureAwait(false);

            // Asserts
            taskAspect.Should().NotBeNull();
            taskAspect.Reference.Code.Should().Be("1");
            taskAspect.Title.Should().Be("Test1");
        }

        [TearDown]
        public async Task Cleanup()
        {
            if(_userStoryDbContext != null)
            {
                await _userStoryDbContext.DisposeAsync().ConfigureAwait(false);
            }
        }
    }
}