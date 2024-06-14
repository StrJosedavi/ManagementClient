using System.ComponentModel.DataAnnotations;

namespace WassamaraManagement.DTOs
{
    public class AuthenticateDto
    {
        [Required(ErrorMessage = "Username é obrigatório")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password é obrigatório")]
        public string Password { get; set; }
    }
}
