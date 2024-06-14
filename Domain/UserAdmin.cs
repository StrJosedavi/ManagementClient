using Microsoft.EntityFrameworkCore;

namespace WassamaraManagement.Domain
{
    [PrimaryKey(nameof(Id))]
    public class UserAdmin
    {
        public long Id { get; set; }
        public string Password { get; set; }

        public string Username { get; set; }
    }
}
