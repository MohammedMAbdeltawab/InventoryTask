using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryTask.Entities
{
    public class ProductWarehouse
    {
        public int Quantity { get; set; }

        [ForeignKey("Product")]
        public int ProductID { get; set; }
        public Product Product { get; set; }

        [ForeignKey("Warehouse")]
        public int WarehouseID { get; set; }
        public Warehouse Warehouse { get; set; }


    }
}
