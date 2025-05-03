using InventoryTask.Dtos.Product;
using InventoryTask.Dtos.WareHouse;
using InventoryTask.Entities;

namespace InventoryTask.Dtos.Transaction
{
    public class TransactionResponse
    {
        public int ID { get; set; }
        public TransactionType TransactionType { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        public int ProductID { get; set; }
        public int SourceWarehouseID { get; set; }
        public int TargetWarehouseID { get; set; }

    }
}
