using InventoryTask.Entities;

namespace InventoryTask.Dtos.Transaction
{
    public class TransactionReport
    {
        public int ID { get; set; }
        public TransactionType TransactionType { get; set; }
        public int Quantity { get; set; }
        public DateTime TransactionDate { get; set; }
        public int ProductID { get; set; }
        public int SourceWarehouseID { get; set; }
        public int TargetWarehouseID { get; set; }
        public int WareHouseID { get; set; }
    }
}
