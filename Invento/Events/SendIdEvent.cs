using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invento.Events
{
    public class SendIdEvent: PubSubEvent<SendIdEventArgs>
    {
    }

    public class SendIdEventArgs
    {
        public int ItemID { get; set; }
        public int Quantity { get; set; }
    }
}
