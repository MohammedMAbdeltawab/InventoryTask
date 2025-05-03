using System.Text.Json.Serialization;

namespace InventoryTask.Dtos.Product
{
    public class ProductDto
    {
        [JsonIgnore]
        public int ID { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int LowStockThreshold { get; set; }
        public int CategoryID { get; set; }
    }
}
