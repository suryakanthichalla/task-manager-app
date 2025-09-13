using TaskManager.Infra.Repositories;

namespace TaskManager.Tests.InfraTest
{
    public class InMemoryTaskRepositoryFixture
    {
        public InMemoryTaskRepository Repository { get; }

        public InMemoryTaskRepositoryFixture()
        {
            Repository = new InMemoryTaskRepository();
        }

    }
}
