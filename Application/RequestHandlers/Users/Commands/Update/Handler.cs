namespace Application.RequestHandlers.Users.Commands.Update
{

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

            var user = await dataAccessLayer.GetById(requestPayload.Id);

            user = mapper.MapToEntity(requestPayload, user);

            await dataAccessLayer.Update(user);

            var response = mapper.MapToResponse(user);
            return ArfBlocksResults.Success(response);
        }
    }
}