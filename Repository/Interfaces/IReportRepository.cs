using InventoryTask.Dtos.Product;
using InventoryTask.Dtos.Report;
using InventoryTask.Dtos.Transaction;
using InventoryTask.Entities;

namespace InventoryTask.Repository.Interfaces
{
    public interface IReportRepository
    {
        public List<Product> LowStockReport(ProductReportDto report);
        public List<Transaction> TransactionHistoryReport(TransactionHistoryReportDto report);

    }
}
