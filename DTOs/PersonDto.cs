using System.ComponentModel.DataAnnotations;
using WassamaraManagement.Domain.Enums;

namespace WassamaraManagement.DTOs
{
    public class PersonDto
    {
        public PersonType Type { get; set; }
        public string? Address { get; set; }

        [Required(ErrorMessage = "Email inválido")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Phone inválido")]
        public string Phone { get; set; }
        public NaturalPersonDto? NaturalPerson { get; set; }
        public PersonJuridicalDto? PersonJuridical { get; set; }
    }
}
