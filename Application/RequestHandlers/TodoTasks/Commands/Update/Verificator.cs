namespace Application.RequestHandlers.TodoTasks.Commands.Update
{
    public class Verificator : IRequestVerificator
    {
        private readonly CurrentUserService _currentUser;
        private readonly DbVerificationService _dbVerificator;
        public Verificator(ArfBlocksDependencyProvider dependencyProvider)
        {
            _dbVerificator = dependencyProvider.GetInstance<DbVerificationService>();
            _currentUser = dependencyProvider.GetInstance<CurrentUserService>();
        }

        public async Task VerificateActor(IRequestModel payload, EndpointContext context, CancellationToken cancellationToken)
        {
            var requestPayload = (RequestModel)payload;
            var currentUserId = _currentUser.GetCurrentUserId();

            await _dbVerificator.VerifyUserIsTaskOwner(requestPayload.Id, currentUserId);
        }

        public async Task VerificateDomain(IRequestModel payload, EndpointContext context, CancellationToken cancellationToken)
        {
            var requestPayload = (RequestModel)payload;
            await _dbVerificator.VerifyTaskStatusIsPending(requestPayload.Id);
        }
    }
}