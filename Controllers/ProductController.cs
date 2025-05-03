using Microsoft.AspNetCore.Mvc;
using InventoryTask.Entities;
using InventoryTask.Service.Interfaces;
using InventoryTask.Dtos.Product;

namespace InventoryTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController(IProductService productService) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await productService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await productService.GetByIdAsync(id);
            if (product != null)
            {
                return Ok(product);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                await productService.AddAsync(productDto);
                return Ok("Added Successfully");
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                    await productService.UpdateAsync(productDto);

                    return Ok("Updated Successfully");
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await productService.DeleteAsync(id);
            return Ok("Deleted Successfully");
        }
    }
}
