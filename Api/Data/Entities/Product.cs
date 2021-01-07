using AcademyApi.Data.Entities;
using System.Collections.Generic;

namespace Api.Data.Entities
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}