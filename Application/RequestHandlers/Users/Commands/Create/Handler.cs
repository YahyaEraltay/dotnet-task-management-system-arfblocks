namespace Application.RequestHandlers.Users.Commands.Create
{
    [AllowAnonymousHandler]
    public class Handler : IRequestHandler
    {
        private readonly DataAccess dataAccessLayer;

        public Handler(ArfBlocksDependencyProvider dependencyProvider, object dataAccess)
        {
            dataAccessLayer = (DataAccess)dataAccess;
        }

        public async Task<ArfBlocksRequestResult> Handle(IRequestModel payload, EndpointContext context, CancellationToken cancellationToken)
        {
            var mapper = new Mapper();
            var requestPayload = (RequestModel)payload;

            var user = mapper.MapToNewEntity(requestPayload);

            await dataAccessLayer.Add(user);

            var response = mapper.MapToResponse(user);
            return ArfBlocksResults.Success(response);
        }
    }
}