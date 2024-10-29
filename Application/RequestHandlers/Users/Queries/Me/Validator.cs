namespace Application.RequestHandlers.Users.Queries.Me
{
    public class Validator : IRequestValidator
    {
        private readonly DbValidationService _dbValidator;

        public Validator(ArfBlocksDependencyProvider dependencyProvider)
        {
            _dbValidator = dependencyProvider.GetInstance<DbValidationService>();
        }

        public async Task ValidateDomain(IRequestModel payload, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }
        public void ValidateRequestModel(IRequestModel payload, CancellationToken cancellationToken)
        {
            
        }
    }
}