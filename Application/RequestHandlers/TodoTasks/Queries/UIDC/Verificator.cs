namespace Application.RequestHandlers.TodoTasks.Queries.UIDC;

public class Verificator : IRequestVerificator
{
    private readonly DbVerificationService _dbVerificator;
    public Verificator(ArfBlocksDependencyProvider dependencyProvider)
    {
        _dbVerificator = dependencyProvider.GetInstance<DbVerificationService>();
    }

    public async Task VerificateActor(IRequestModel payload, EndpointContext context, CancellationToken cancellationToken)
    {
        var requestPayload = (RequestModel)payload;

        // NOP:
        await Task.CompletedTask;
    }

    public async Task VerificateDomain(IRequestModel payload, EndpointContext context, CancellationToken cancellationToken)
    {
        var requestPayload = (RequestModel)payload;

        // NOP:
        await Task.CompletedTask;
    }
}