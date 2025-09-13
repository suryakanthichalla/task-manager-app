using TaskManager.Domain;

namespace TaskManager.Application.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskItem>> GetAllTasks();
        Task<TaskItem?> GetTaskById(int id);
        Task AddUpdateTask(IEnumerable<TaskItem> tasks);
        Task DeleteTask(int id);
    }
}
