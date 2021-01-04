using System.Collections.Generic;

namespace AcademyApi.Data.Entities
{
    public class User:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string Password { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
