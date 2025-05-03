using InventoryTask.Dtos.Product;
using InventoryTask.Dtos.Report;
using InventoryTask.Dtos.Transaction;
using InventoryTask.Entities;

namespace InventoryTask.Service.Interfaces
{
    public interface IReportService
    {
        public List<LowStockReportDto> LowStockReport(ProductReportDto report);
        public List<TransactionHistoryReportDto> TransactionHistoryReport(TransactionHistoryReportDto report);
    }
}
