using InventoryTask.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryTask.Dtos.ProductWareHouse
{
    public class ProductWareHouseDto
    {

        public int Quantity { get; set; }

        public int ProductID { get; set; }

        public int WarehouseID { get; set; }
    }
}
