using TaskManager.Domain;
using TaskManager.Infra.Repositories;

namespace TaskManager.Tests.InfraTest
{
    public class InMemoryTaskRepositoryTest : IClassFixture<InMemoryTaskRepositoryFixture>
    {
        private readonly InMemoryTaskRepository inMemoryTaskRepository;
        public InMemoryTaskRepositoryTest(InMemoryTaskRepositoryFixture fixture)
        {
            this.inMemoryTaskRepository = fixture.Repository;
        }
        List<TaskItem> tasks = new List<TaskItem>()
        {
            new TaskItem() { Id = 1, Title = "Test Task1", Description = "Test Description" },
            new TaskItem() { Id = 2, Title = "Test Task2", Description = "Test Description" }
        };
        [Fact]
        public async Task AddUpdateTask_ShouldStoreTask()
        {
            //Arrange

            //Act
            await inMemoryTaskRepository.AddUpdateTask(tasks);
            var storedTask = await inMemoryTaskRepository.GetTaskById(2);
            tasks = [new TaskItem() { Id = 2, Title = "Updated Task", Description = "Test Description 1" }];
            await inMemoryTaskRepository.AddUpdateTask(tasks);
            var updated = await inMemoryTaskRepository.GetTaskById(2);
            //Assert
            Assert.NotNull(storedTask);
            Assert.NotNull(updated);
            Assert.NotEqual(updated.Title, storedTask?.Title);
        }
        [Fact]
        public async Task DeleteTask_ShouldDeleteTask()
        {
            //Arrange
            //Act
            await inMemoryTaskRepository.AddUpdateTask(tasks);
            await inMemoryTaskRepository.DeleteTask(1);
            var taskCount = await inMemoryTaskRepository.GetAllTasks();
            //Assert
            Assert.True(taskCount.Count() == 1);
        }
    }
}