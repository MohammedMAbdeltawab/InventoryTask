namespace InventoryTask.Entities
{
    public class Warehouse : BaseClass
    {
        public string Location { get; set; }
        public List <ProductWarehouse> ProductWarehouses { get; set; }
    }
}
