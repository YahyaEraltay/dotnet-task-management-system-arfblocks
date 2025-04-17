namespace Application.RequestHandlers.Users.Commands.Login;

public class Verificator : IRequestVerificator
{
    private readonly ApplicationDbContext _dbContext;

    public Verificator(ArfBlocksDependencyProvider dependencyProvider)
    {
        _dbContext = dependencyProvider.GetInstance<ApplicationDbContext>();
    }

    public async Task VerificateActor(IRequestModel payload, EndpointContext context, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    public async Task VerificateDomain(IRequestModel payload, EndpointContext context, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }
}