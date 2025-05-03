using InventoryTask.Dtos.Product;
using InventoryTask.Dtos.WareHouse;
using InventoryTask.Service.Interfaces;
using InventoryTask.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WareHouseController(IWareHouseService wareHouseService) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await wareHouseService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await wareHouseService.GetByIdAsync(id);
            if (product != null)
            {
                return Ok(product);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create(WareHouseRequest wareHouseRequest)
        {
            if (ModelState.IsValid)
            {
                await wareHouseService.AddAsync(wareHouseRequest);
                return Ok("Added Successfully");
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, WareHouseResponce wareHouseResponce)
        {
            if (ModelState.IsValid)
            {
                await wareHouseService.UpdateAsync(wareHouseResponce);

                return Ok("Updated Successfully");
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await wareHouseService.DeleteAsync(id);
            return Ok("Deleted Successfully");
        }

    }
}
