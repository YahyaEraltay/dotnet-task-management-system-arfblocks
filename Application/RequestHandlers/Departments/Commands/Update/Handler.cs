namespace Application.RequestHandlers.Departments.Commands.Update
{

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

            var department = await dataAccessLayer.GetById(requestPayload.Id);

            department = mapper.MapToEntity(requestPayload, department);

            await dataAccessLayer.Update(department);

            var response = mapper.MapToResponse(department);
            return ArfBlocksResults.Success(response);
        }
    }
}