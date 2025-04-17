namespace Application.RequestHandlers.Departments.Commands.Delete;

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

        var department = await _dataAccessLayer.GetDepartmentById(requestPayload.Id);

        mapper.MapToEntity(department, requestPayload);

        await _dataAccessLayer.UpdateDepartment(department);

        var response = mapper.MapToResponse(department);
        return ArfBlocksResults.Success(response);
    }
}