using InventoryTask.Dtos.Product;
using InventoryTask.Dtos.Report;
using InventoryTask.Service.Interfaces;
using InventoryTask.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController(IReportService reportService) : ControllerBase
    {
        [HttpPost]
        public IActionResult GetLowStockReport(ProductReportDto report)
        {
            if (report == null)
                return BadRequest("Report parameters are required.");

            var result =  reportService.LowStockReport(report);
            return Ok(result);
        }

        [HttpPost("transaction-history")]
        public async Task<IActionResult> GetTransactionHistoryReport(TransactionHistoryReportDto report)
        {
            if (report == null)
                return BadRequest("Report parameters are required.");

            var result = reportService.TransactionHistoryReport(report);
            return Ok(result);
        }

    }
}
