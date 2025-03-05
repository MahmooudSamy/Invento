
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Invento.Model
{
    public class InventoryItem
    {
        [Key, Column(Order = 0)]
        public int ItemId { get; set; }

        [Key, Column(Order = 1)]
        public int InventoryId { get; set; }

        public int Quantity { get; set; }
        public DateTime LastUpdate { get; set; }
        public  Item Item { get; set; }
        public  Inventory Inventory { get; set; }
    }
}
