
namespace Application.RequestHandlers.Departments.Queries.All
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
//TODO: Burayı boş bırak ya da sil
        public void ValidateRequestModel(IRequestModel payload, CancellationToken cancellationToken)
        {
            
        }
    }
}