using System.ComponentModel.DataAnnotations;

namespace Invento.Model
{
    public  class Item
    {
        public Item()
        {
            InventoryItems = new HashSet<InventoryItem>();
        }
        [Key]
        public int ItemId { get; set; }

        [Required]
        [MaxLength(100)]
        public required string ItemName { get; set; }

        public int CategoryId { get; set; }

        
        public  Category Category { get; set; }

        public virtual ICollection<InventoryItem> InventoryItems { get; set; }
    }
}
