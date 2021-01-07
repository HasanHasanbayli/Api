using System.Collections.Generic;

namespace Api.Resources.Category
{
    public class CategoryResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AddedDate { get; set; }
        public ICollection<string> Products { get; set; }
    }
}
