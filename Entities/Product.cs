using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryTask.Entities
{
    public class Product : BaseClass
    {
        [MinLength(2), MaxLength(100)]

        public string? Description { get; set; }

        public decimal price { get; set; }
        public int LowStockThreshold { get; set; }

        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public Category Category { get; set; }


        public List<ProductWarehouse> ProductWarehouses { get; set; }
        public List<Transaction> Transactions { get; set; }



        //Name, Description, Quantity, Price, and LowStockThreshold.
    }
}
