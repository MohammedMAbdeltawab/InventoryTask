using System.ComponentModel.DataAnnotations.Schema;
using System.Transactions;

namespace InventoryTask.Entities
{
    public class Transaction //: BaseClass
    {
        public int ID { get; set; }
        public TransactionType TransactionType { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("Product")]
        public int ProductID { get; set; }
        public Product Product { get; set; }

        [ForeignKey("Warehouse")]
        public int? SourceWarehouseID { get; set; }
        public Warehouse? SourceWarehouse { get; set; }

        [ForeignKey("Warehouse")]
        public int TargetWarehouseID { get; set; }
        public Warehouse TargetWarehouse { get; set; }

        //o Each transaction should be recorded with details like TransactionType, Quantity, Date, and User.
    }
    public enum TransactionType
    {
        Add=1,
        Remove=2,
        Transfer=4
    }
}
