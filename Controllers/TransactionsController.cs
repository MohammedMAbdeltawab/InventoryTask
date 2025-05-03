using InventoryTask.Dtos.Transaction;
using InventoryTask.Service.Interfaces;
using InventoryTask.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController(ITransactionService transactionService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await transactionService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Transaction = await transactionService.GetByIdAsync(id);
            if (Transaction != null)
            {
                return Ok(Transaction);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TransactionRequest TransactionRequest)
        {
            if (ModelState.IsValid)
            {
                await transactionService.AddAsync(TransactionRequest);
                return Ok("Added Successfully");
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TransactionResponse TransactionResponse)
        {
            if (ModelState.IsValid)
            {
                TransactionResponse.ID = id;
                await transactionService.UpdateAsync(TransactionResponse);

                return Ok("Updated Successfully");
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await transactionService.DeleteAsync(id);
            return Ok("Deleted Successfully");
        }


    }
}
