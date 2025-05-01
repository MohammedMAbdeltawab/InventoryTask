using System.ComponentModel.DataAnnotations;

namespace InventoryTask.Entities
{
    public class BaseClass
    {
        public int ID { get; set; }
        [MinLength(2),MaxLength(20)]
        public string Name { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
