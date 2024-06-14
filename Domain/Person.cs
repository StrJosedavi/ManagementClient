using Microsoft.EntityFrameworkCore;
using WassamaraManagement.Domain.Enums;

namespace WassamaraManagement.Domain
{
    [PrimaryKey(nameof(Id))]
    public class Person
    {
        public long Id { get; set; }
        public PersonType Type { get; set; }

        public string? Address { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }

        public string? FullName { get; set; }
        public string? CPF { get; set; }
        public DateTime? BirthDate { get; set; }

        public string? CompanyName { get; set; }
        public string? CNPJ { get; set; }
        public string? TradingName { get; set; }
    }
}
