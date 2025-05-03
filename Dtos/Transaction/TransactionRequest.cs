using InventoryTask.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryTask.Dtos.Transaction
{
    public class TransactionRequest
    {
        public TransactionType TransactionType { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        public int ProductID { get; set; }
        public int SourceWarehouseID { get; set; }
        public int TargetWarehouseID { get; set; }

    }
}
