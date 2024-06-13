using WassamaraManagement.DTOs;

namespace WassamaraManagement.Services.Validators
{
    public class PersonValidator
    {
        public static void ValidatePersonDto(PersonDto personDto) 
        {
            if (personDto.NaturalPerson != null && personDto.PersonJuridical != null)
                throw new Exception("");
            if (personDto.NaturalPerson == null && personDto.PersonJuridical == null)
                throw new Exception("");
        }
        public static void ValidatePersonPJ(PersonJuridicalDto personJuridicalDto)
        {
            if (string.IsNullOrWhiteSpace(personJuridicalDto.CompanyName))
                throw new Exception("");
            if (string.IsNullOrWhiteSpace(personJuridicalDto.CNPJ))
                throw new Exception("");
        }
        public static void ValidatePersonPF(NaturalPersonDto naturalPersonDto)
        {
            if (string.IsNullOrWhiteSpace(naturalPersonDto.FullName))
                throw new Exception("");
            if (string.IsNullOrWhiteSpace(naturalPersonDto.CPF))
                throw new Exception("");
        }
    }
}
