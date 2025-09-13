using TaskManager.Application.Interfaces;
using TaskManager.Domain;

namespace TaskManager.Infra.Repositories
{
    public class InMemoryTaskRepository : ITaskRepository
    {
        private readonly static Dictionary<int, TaskItem> Tasks = [];
        /// <summary>
        /// Adds/updates task to the in-memory dictionary
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public Task AddUpdateTask(IEnumerable<TaskItem> tasks)
        {
            foreach (var task in tasks)
            {
                Tasks[task.Id] = task;
            }
            return Task.CompletedTask;
        }
        /// <summary>
        /// Deletes task from the in-memory dictionary
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task DeleteTask(int id)
        {
            Tasks.Remove(id);
            return Task.CompletedTask;
        }
        /// <summary>
        /// Gets all tasks from the in-memory dictionary
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<TaskItem>> GetAllTasks()
        {
            return Task.FromResult(Tasks.Values.AsEnumerable());
        }
        /// <summary>
        /// Gets task by id from the in-memory dictionary
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<TaskItem?> GetTaskById(int id)
        {
            Tasks.TryGetValue(id, out var task);
            return Task.FromResult(task);
        }
    }
}
