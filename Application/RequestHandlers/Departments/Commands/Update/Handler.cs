namespace Application.RequestHandlers.Departments.Commands.Update
{

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

            var department = await _dataAccessLayer
.GetById(requestPayload.Id);

            department = mapper.MapToEntity(requestPayload, department);

            await _dataAccessLayer
.Update(department);

            var response = mapper.MapToResponse(department);
            return ArfBlocksResults.Success(response);
        }
    }
}