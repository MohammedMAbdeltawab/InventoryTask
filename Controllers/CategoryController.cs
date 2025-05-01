using InventoryTask.Service.Interfaces;
using InventoryTask.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(ICategoryService categoryService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult>GetAll() {
            var Categories = await categoryService.GetAllAsync();
            return Ok(Categories);
        }
    }
}
