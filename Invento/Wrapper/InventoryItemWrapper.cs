using Invento.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invento.Wrapper
{
    public class InventoryItemWrapper : ModelWrapper<InventoryItem>
    {
        public InventoryItemWrapper(InventoryItem model) : base(model)
        {
                
        }
        public int Id { get { return Model.ItemId; } }
        public int InventoryId { get { return Model.InventoryId; } }

        public int Quantity
        {
            get { return GetValue<int>(); }
            set { SetValue(value); }
        }
        public DateTime LastUpdate
        {
            get { return GetValue<DateTime>(); }
            set { SetValue(value); }
        }

        protected override IEnumerable<string> ValidateProperty(string propertyName)
        {
            switch (propertyName)
            {
                case nameof(Quantity):
                    if (Quantity < 0) 
                    {
                        yield return "Quantity cannot be negative.";
                    }
                    break;

            }
        }


    }
}
