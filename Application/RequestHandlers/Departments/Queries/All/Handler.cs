namespace Application.RequestHandlers.Departments.Queries.All
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

            (var departments, var pageResponse) = await _dataAccessLayer.GetAllDepartments(requestPayload.Sorting, requestPayload.Filters, requestPayload.PageRequest);

            var response = mapper.MapToResponse(departments);
            return ArfBlocksResults.Success(response, pageResponse);
        }
    }
}