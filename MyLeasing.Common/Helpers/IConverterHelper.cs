using MyLeasing.Common.Data.Entities;
using MyLeasing.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeasing.Common.Helpers
{
    public interface IConverterHelper
    {
        Owner ToOwner(OwnerViewModel model, string path, bool isNew);

        OwnerViewModel ToOwnerViewModel(Owner owner);

        Lessee ToLessee(LesseeViewModel model, string path, bool isNew);

        LesseeViewModel ToLesseeViewModel(Lessee lessee);
    }
}
