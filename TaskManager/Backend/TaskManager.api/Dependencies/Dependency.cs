using TaskManager.Application.Interfaces;
using TaskManager.Infra.Repositories;

namespace TaskManager.API.Dependencies
{
    public static class Dependency
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            // Add other dependencies here as needed
            services.AddSingleton<ITaskRepository, InMemoryTaskRepository>();
        }
    }
}
