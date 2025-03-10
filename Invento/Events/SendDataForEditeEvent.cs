using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invento.Events
{
    public class SendDataForEditeEvent:PubSubEvent<SendDataForEditeEventArgs>
    {
    }

    public class SendDataForEditeEventArgs
    {
        public int ItemID { get; set; }
        public int Quantity { get; set; }
        public EventState State { get; set; }
    }

    public enum EventState
    {
        AddNew,
        Edit,
        View
    }
}
