namespace Application.RequestHandlers.Departments.Queries.All
{
    public class Handler : IRequestHandler
    {
        private readonly DataAccess _dataAccessLayer;
        private readonly DbValidationService _dbValidationService;
        public Handler(ArfBlocksDependencyProvider dependencyProvider, object dataAccess)
        {
            _dataAccessLayer = (DataAccess)dataAccess;
            _dbValidationService = dependencyProvider.GetInstance<DbValidationService>();
        }

        public async Task<ArfBlocksRequestResult> Handle(IRequestModel payload, CancellationToken cancellationToken)
        {
            var mapper = new Mapper();
            var allDepartments = await _dataAccessLayer.All();

            var mappedDepartments = mapper.MapToResponse(allDepartments);
            return ArfBlocksResults.Success(mappedDepartments);
        }
    }
}