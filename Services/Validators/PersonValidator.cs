using WassamaraManagement.DTOs;
using WassamaraManagement.Middleware.Exceptions;

namespace WassamaraManagement.Services.Validators
{
    public class PersonValidator
    {
        public static void ValidatePersonDto(PersonDto personDto) 
        {
            if (personDto.NaturalPerson != null && personDto.PersonJuridical != null)
                throw new BadRequestException("Enviar apenas os dados do tipo de pessoa informada");
            if (personDto.NaturalPerson == null && personDto.PersonJuridical == null)
                throw new BadRequestException("Enviar ao menos as informações de um tipo de pessoa");
        }
        public static void ValidatePersonPJ(PersonJuridicalDto personJuridicalDto)
        {
            if (string.IsNullOrWhiteSpace(personJuridicalDto.CompanyName))
                throw new BadRequestException("Razão Social Inválida");
            if (string.IsNullOrWhiteSpace(personJuridicalDto.CNPJ))
                throw new BadRequestException("CNPJ não informado");
        }
        public static void ValidatePersonPF(NaturalPersonDto naturalPersonDto)
        {
            if (string.IsNullOrWhiteSpace(naturalPersonDto.FullName))
                throw new BadRequestException("Informar nome completo");
            if (string.IsNullOrWhiteSpace(naturalPersonDto.CPF))
                throw new BadRequestException("CPF não informado");
        }
    }
}
