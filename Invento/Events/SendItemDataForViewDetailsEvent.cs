using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invento.Events
{
    public class SendItemDataForViewDetailsEvent: PubSubEvent<SendItemDataForViewDetailsEventArgs>
    {
    }

    public class SendItemDataForViewDetailsEventArgs
    {
        public int ItemId { get; set; }
        public  string ItemName { get; set; }
        public  string CategoryName { get; set; }
        public int  Quantity { get; set; }
        public  DateTime LastUpdate { get; set; }
    }
}
