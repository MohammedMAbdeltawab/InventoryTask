using InventoryTask.Dtos.Product;
using InventoryTask.Dtos.Report;
using InventoryTask.Dtos.Transaction;
using InventoryTask.Entities;
using InventoryTask.Repository.Interfaces;
using InventoryTask.Repository.Reposatories;
using InventoryTask.Service.Interfaces;

namespace InventoryTask.Service.Services
{
    public class ReportService(IReportRepository reportRepository) : IReportService
    {
        public List<LowStockReportDto> LowStockReport(ProductReportDto report)
        {
            var products = reportRepository.LowStockReport(report);
            var result = new List<LowStockReportDto>();

            foreach (var product in products)
            {
                var stockQuery = product.ProductWarehouses.AsQueryable();
                if (report.WareHouseID > 0)
                    stockQuery = stockQuery.Where(pw => pw.WarehouseID == report.WareHouseID);

                var totalStock = stockQuery.Sum(pw => pw.Quantity);

                result.Add(new LowStockReportDto
                {
                    ProductID = product.ID,
                    ProductName = product.Name,
                    CategoryID = product.CategoryID,
                    LowStockThreshold = product.LowStockThreshold,
                    TotalStock = totalStock,
                    WarehouseID = report.WareHouseID
                });
            }

            return result;
        }

        public List<TransactionHistoryReportDto> TransactionHistoryReport(TransactionHistoryReportDto report)
        {

            var transactions = reportRepository.TransactionHistoryReport(report);
            var result= transactions.Select(t => new TransactionHistoryReportDto
            {
                ID = t.ID,
                TransactionType = t.TransactionType,
                Quantity = t.Quantity,
                Date = t.Date,
                ProductID = t.ProductID,
                SourceWarehouseID = t.SourceWarehouseID,
                TargetWarehouseID = t.TargetWarehouseID,
            }).ToList();
            return result;
        }

    }
}
