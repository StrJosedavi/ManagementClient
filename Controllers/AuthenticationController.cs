using Microsoft.AspNetCore.Mvc;
using WassamaraManagement.DTOs;
using WassamaraManagement.Services.Interfaces;

namespace WassamaraManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticateService _authenticateService;

        public AuthenticationController(IAuthenticateService authenticationService)
        {
            _authenticateService = authenticationService;
        }

        /// <summary>
        /// Autenticação de usuário e geração de token de acesso
        /// </summary>
        /// <param name="authenticateDto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Authenticate([FromBody] AuthenticateDto authenticateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var acessToken = _authenticateService.Authenticate(authenticateDto);

            return Ok(new { acessToken, Message = "Authenticação concluída!" });
        }
    }
}