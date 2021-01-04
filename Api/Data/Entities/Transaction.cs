using AcademyApi.Data.Enums;

namespace AcademyApi.Data.Entities
{
    public class Transaction:BaseEntity
    {
        public TransactionType Type { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
    }
}