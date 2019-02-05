using System.Collections.Generic;

namespace ProductShop.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<CategoryProduct> Products { get; set; } = new HashSet<CategoryProduct>();
    }
}
