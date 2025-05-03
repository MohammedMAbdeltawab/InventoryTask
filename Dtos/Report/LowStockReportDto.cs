namespace InventoryTask.Dtos.Report
{
    public class LowStockReportDto
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int LowStockThreshold { get; set; }
        public int TotalStock { get; set; }
        public int? WarehouseID { get; set; }
    }
}
