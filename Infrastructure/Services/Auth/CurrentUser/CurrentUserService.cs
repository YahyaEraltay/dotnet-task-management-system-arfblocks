using System.Threading.Tasks;
using Arfware.ArfBlocks.Core;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Services;

public class CurrentUserService
{
    private CurrentUserModel _currentUser;
    private readonly IHttpContextAccessor _httpContextAccessor;
    // private readonly CustomLogger _logger;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor, ArfBlocksDependencyProvider dependencyProvider, EnvironmentService environmentService, CurrentUserModel identifiedClient)
    {
        _httpContextAccessor = httpContextAccessor;

        if (environmentService.Environment == CustomEnvironments.Test)
        {
            this._currentUser = identifiedClient;
        }
        else
        {
            this._currentUser = ParseJwt().Result;
        }
        // _logger = dependencyProvider.GetInstance<CustomLogger>();
    }


    private async Task<CurrentUserModel> ParseJwt()
    {
        try
        {
            var auhtorizatioValue = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].FirstOrDefault();
            if (auhtorizatioValue != null)
            {
                // format: [Authorization : Baerer eykjdsfjajfkl230423ujre2r23rnnj]
                string jwtInput = auhtorizatioValue.Split(' ')[1];

                var jwtHandler = new JwtSecurityTokenHandler();

                // Check Token Format
                if (!jwtHandler.CanReadToken(jwtInput)) throw new Exception("Invalid JWT format.");

                var token = jwtHandler.ReadJwtToken(jwtInput);

                // Get Claims
                var name = token.Claims.FirstOrDefault(c => c.Type == "given_name").Value;
                var userId = Guid.Parse(token.Claims.FirstOrDefault(c => c.Type == "nameid").Value);
                // var departmentId = Guid.Parse(token.Claims.FirstOrDefault(c => c.Type == "department_id").Value);

                var _currentUser = new CurrentUserModel()
                {
                    Id = userId,
                    FirstName = name,
                    // DepartmentId = departmentId,
                };

                return _currentUser;
            }
        }
        catch (Exception exception)
        {
            // await _logger.Error($"CurrentUserService JWT Parsing Error Message: {exception.Message}");
            // await _logger.Error($"CurrentUserService JWT Parsing Error Message: {exception.InnerException?.Message}");
            // await _logger.Error($"CurrentUserService JWT Parsing Error Stack Trace: {exception.StackTrace}");
            // await _logger.Error($"CurrentUserService JWT Parsing Error Stack Trace: {exception.InnerException?.StackTrace}");

            Console.WriteLine($"CurrentUserService JWT Parsing Error Message: {exception.Message}");
            Console.WriteLine($"CurrentUserService JWT Parsing Error Message: {exception.InnerException?.Message}");
            Console.WriteLine($"CurrentUserService JWT Parsing Error Stack Trace: {exception.StackTrace}");
            Console.WriteLine($"CurrentUserService JWT Parsing Error Stack Trace: {exception.InnerException?.StackTrace}");
        }

        return null;
    }
    public CurrentUserModel GetCurrentUser()
    {
        return this._currentUser;
    }

    public Guid GetCurrentUserId()
    {
        return this._currentUser.Id;
    }

    public Guid GetCurrentUserDepartmentId()
    {
        return this._currentUser.DepartmentId;
    }

    public string GetCurrentUserDisplayName()
    {
        return this._currentUser.FirstName;
    }
}