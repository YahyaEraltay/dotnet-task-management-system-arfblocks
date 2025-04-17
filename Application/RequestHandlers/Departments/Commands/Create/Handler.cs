namespace Application.RequestHandlers.Departments.Commands.Create;

public class Handler : IRequestHandler
{
    private readonly DataAccess _dataAccessLayer;


    public Handler(ArfBlocksDependencyProvider dependencyProvider, object dataAccess)
    {
        _dataAccessLayer = (DataAccess)dataAccess;

    }

    public async Task<ArfBlocksRequestResult> Handle(IRequestModel payload, EndpointContext context, CancellationToken cancellationToken)
    {
        var mapper = new Mapper();
        var requestPayload = (RequestModel)payload;

        var department = mapper.MapToNewEntity(requestPayload);

        await _dataAccessLayer.Add(department);

        var response = mapper.MapToResponse(department);
        return ArfBlocksResults.Success(response);
    }
}