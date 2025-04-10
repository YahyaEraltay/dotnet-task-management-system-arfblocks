namespace Application.RequestHandlers.Users.Commands.Create
{
    [AllowAnonymousHandler]
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

            var user = mapper.MapToNewEntity(requestPayload);

            await _dataAccessLayer.AddUser(user);

            var response = mapper.MapToResponse(user);
            return ArfBlocksResults.Success(response);
        }
    }
}