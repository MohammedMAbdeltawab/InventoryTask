using System.ComponentModel.DataAnnotations;

namespace InventoryTask.Dtos.WareHouse
{
    public class WareHouseRequest
    {
        public string Name { get; set; }
        public string Location { get; set; }
    }
}
