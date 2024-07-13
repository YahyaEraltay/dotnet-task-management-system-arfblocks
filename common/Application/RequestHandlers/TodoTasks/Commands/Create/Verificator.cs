namespace Application.RequestHandlers.TodoTasks.Commands.Create
{
    public class Verificator : IRequestVerificator
    {
        private readonly ApplicationDbContext _dbContext;

        public Verificator(ArfBlocksDependencyProvider dependencyProvider)
        {
            _dbContext = dependencyProvider.GetInstance<ApplicationDbContext>();
        }

        public async Task VerificateActor(IRequestModel payload, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }

        public async Task VerificateDomain(IRequestModel payload, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }
    }
}