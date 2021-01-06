using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AcademyApi.Data.Entities
{
    public class User:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string Password { get; set; }
    }
}
