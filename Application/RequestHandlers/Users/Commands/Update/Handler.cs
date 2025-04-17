namespace Application.RequestHandlers.Users.Commands.Update;

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

        var user = await _dataAccessLayer.GetUserById(requestPayload.Id);

        user = mapper.MapToEntity(requestPayload, user);

        await _dataAccessLayer.UpdateUser(user);

        var response = mapper.MapToResponse(user);
        return ArfBlocksResults.Success(response);
    }
}