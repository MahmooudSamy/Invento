using Invento.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invento.Wrapper
{
    public class CategoryWrapper: ModelWrapper<Category>
    {
        public CategoryWrapper(Category model) : base(model)
        {
                
        }
        public int Id { get { return Model.CategoryId; } }
        public string CategoryName
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
    }
}
