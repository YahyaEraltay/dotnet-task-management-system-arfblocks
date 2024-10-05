
namespace Application.RequestHandlers.SyncDatas.Commands.SyncStationData
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
            var requestPayload = (RequestModel)payload;

            await _dbValidator.ValidateLicenseNoAndSubLicenseNoExist(requestPayload.LicenseNo, requestPayload.SubLicenseNo);
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
            RuleFor(x => x.LicenseNo)
                    .NotNull().WithMessage(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.CommonErrors.NameNotValid))
                    .NotEmpty().WithMessage(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.CommonErrors.NameNotValid));

            RuleFor(x => x.SubLicenseNo)
            .NotNull().WithMessage(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.CommonErrors.NameNotValid))
            .NotEmpty().WithMessage(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.CommonErrors.NameNotValid));
        }
    }
}

