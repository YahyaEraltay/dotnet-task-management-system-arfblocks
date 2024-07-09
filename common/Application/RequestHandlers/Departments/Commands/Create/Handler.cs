
namespace Application.RequestHandlers.Departments.Commands.Create
{

    [AllowAnonymousHandler]
    public class Handler : IRequestHandler
    {
        private readonly DataAccess dataAccessLayer;

        public Handler(ArfBlocksDependencyProvider dependencyProvider, object dataAccess)
        {
            dataAccessLayer = (DataAccess)dataAccess;
        }

        public async Task<ArfBlocksRequestResult> Handle(IRequestModel payload, CancellationToken cancellationToken)
        {
            var mapper = new Mapper();
            var requestPayload = (RequestModel)payload;

            var department = mapper.MapToNewEntity(requestPayload);

            await dataAccessLayer.Add(department);

            var response = mapper.MapToResponse(department);
            return ArfBlocksResults.Success(response);
        }
    }
}