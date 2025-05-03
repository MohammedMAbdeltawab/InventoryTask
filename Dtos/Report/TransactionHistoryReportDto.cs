using InventoryTask.Entities;

namespace InventoryTask.Dtos.Report
{
    public class TransactionHistoryReportDto
    {
        public int ID { get; set; }
        public TransactionType TransactionType { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int? SourceWarehouseID { get; set; }
        public string SourceWarehouseName { get; set; }
        public int TargetWarehouseID { get; set; }
        public string TargetWarehouseName { get; set; }
    }
}
