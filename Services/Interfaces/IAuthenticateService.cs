using WassamaraManagement.DTOs;

namespace WassamaraManagement.Services.Interfaces
{
    public interface IAuthenticateService
    {
        object Authenticate(AuthenticateDto authenticateDto);
    }
}

