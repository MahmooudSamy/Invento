using Invento.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invento.DataAccess.Data.Lookups
{
   public interface ICategoriesLookup
    {
        Task<IEnumerable<CategoryDto>> GetCategoryList();
    }
}
