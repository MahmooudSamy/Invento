using System.ComponentModel.DataAnnotations;

namespace Invento.Model
{
    public class Inventory
    {
        public Inventory()
        {
            InventoryItems = new HashSet<InventoryItem>();
        }
        [Key]
        public int InventoryId { get; set; }

        [Required]
        [MaxLength(50)]
        public  string InventoryName { get; set; }

        public virtual ICollection<InventoryItem>  InventoryItems { get; set; }
    }
}
