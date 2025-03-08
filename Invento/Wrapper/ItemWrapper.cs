using Invento.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invento.Wrapper
{
    public class ItemWrapper : ModelWrapper<Item>
    {
        public ItemWrapper(Item model) : base(model)
        {
        }
        public int Id { get { return Model.ItemId; } }

        public string ItemName
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public int CategoryId
        {
            get { return GetValue<int>(); }
            set { SetValue(value); }
        }

        protected override IEnumerable<string> ValidateProperty(string propertyName)
        {
            switch (propertyName)
            {
                case nameof(ItemName):
                    if (string.Equals(ItemName, "Robot", StringComparison.OrdinalIgnoreCase))
                    {
                        yield return "Robots are not valid item";
                    }
                    break;
                  
            }
        }
    }
}
