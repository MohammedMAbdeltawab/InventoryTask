using System.ComponentModel.DataAnnotations;

namespace InventoryTask.Entities
{
    public class Category : BaseClass
    {
        [MinLength(2), MaxLength(100)]

        public string Description { get; set; }
        public List<Product> Products { get; set; }

    }
}
