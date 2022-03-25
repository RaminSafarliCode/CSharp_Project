using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Infrustucture
{
    internal enum Menu : byte
    {
        BrandAdd = 1,
        BrandEdit,
        BrandRemove,
        BrandSingle,
        BrandsAll,

        ModelAdd,
        ModelEdit,
        ModelRemove,
        ModelSingle,
        ModelsAll,

        CarAdd,
        CarEdit,
        CarRemove,
        CarSingle,
        CarsAll,

        All,
        Exit
    }
}
