using AcademyApi.Data.Entities;

namespace Api.Data.Entities
{
    public class ProductCategory:BaseEntity
    {
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}