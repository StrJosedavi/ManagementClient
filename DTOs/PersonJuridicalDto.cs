namespace WassamaraManagement.DTOs
{
    public class PersonJuridicalDto
    {
        // Razão Social
        public string CompanyName { get; set; }
        public string CNPJ { get; set; }

        // Nome Fantasia
        public string? TradingName { get; set; }
    }
}
