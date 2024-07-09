
namespace Application.RequestHandlers.Departments.Commands.Create
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
            var requestModel = (RequestModel)payload;

            var validationResult = new RequestModel_Validator().Validate(requestModel);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.ToString("~");
                throw new ArfBlocksValidationException(errors); 
            }
        }


    }
    
    public class RequestModel_Validator : AbstractValidator<RequestModel>
    {
        public RequestModel_Validator()
        {
            RuleFor(x => x.Name)
                    .NotNull().WithMessage(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.UserErrors.NameNotValid));
        }
    }
}

