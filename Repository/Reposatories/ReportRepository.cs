using InventoryTask.Data;
using InventoryTask.Dtos.Product;
using InventoryTask.Dtos.Report;
using InventoryTask.Dtos.Transaction;
using InventoryTask.Entities;
using InventoryTask.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace InventoryTask.Repository.Reposatories
{
    public class ReportRepository(IReportRepository reportRepository, ApplicationDbContext context) : IReportRepository
    {
        public List<Product> LowStockReport(ProductReportDto report)
        {
            var products = reportRepository.LowStockReport(report);
            var result = new List<Product>();

            foreach (var product in products)
            {
                var stockQuery = product.ProductWarehouses.AsQueryable();
                if (report.WareHouseID > 0)
                    stockQuery = stockQuery.Where(pw => pw.WarehouseID == report.WareHouseID);

                var totalStock = stockQuery.Sum(pw => pw.Quantity);

                result.Add(new Product
                {
                    ID = product.ID,
                    Name = product.Name,
                    CategoryID = product.CategoryID,
                    LowStockThreshold = product.LowStockThreshold,
                });
            }

            return result;

        }

        public List<Transaction> TransactionHistoryReport(TransactionHistoryReportDto report)
        {
            var TransactionFromDB = context.Transactions
          .Include(t => t.Product)
          .Include(t => t.SourceWarehouse)
          .Include(t => t.SourceWarehouse)
          .Include(t => t.TargetWarehouse).AsQueryable();

            // Apply filters

            TransactionFromDB = TransactionFromDB
            .Where(t => t.ProductID == report.ProductID)
            .Where(t => t.TransactionType == report.TransactionType)
            .Where(t => t.SourceWarehouseID == report.SourceWarehouseID)
            .Where(t => t.TargetWarehouseID == report.TargetWarehouseID)
            ;
            return TransactionFromDB.ToList();



        }
    }
}
