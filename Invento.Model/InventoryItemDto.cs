using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invento.Model
{
  public  class InventoryItemDto
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string CategoryName { get; set; }
        public int Quantity { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
