namespace InventoryTask.Dtos.Product
{
    public class ProductReportDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int LowStockThreshold { get; set; }
        public int CategoryID { get; set; }
        public int WareHouseID { get; set; }

        // may be need category object !!

    }
}
