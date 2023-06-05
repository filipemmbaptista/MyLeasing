using MyLeasing.Common.Data.Entities;
using MyLeasing.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeasing.Common.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        public Owner ToOwner(OwnerViewModel model, string path, bool isNew)
        {
            return new Owner
            {
                Id = isNew ? 0 : model.Id,
                ImageUrl = path,
                Document = model.Document,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
                FixedPhone = model.FixedPhone,
                CellPhone = model.CellPhone,
                User = model.User,
            };
        }

        public OwnerViewModel ToOwnerViewModel(Owner owner)
        {
            return new OwnerViewModel
            {
                Id = owner.Id,
                ImageUrl = owner.ImageUrl,
                Document = owner.Document,
                FirstName = owner.FirstName,
                LastName = owner.LastName,
                Address = owner.Address,
                FixedPhone = owner.FixedPhone,
                CellPhone = owner.CellPhone,
                User = owner.User,
            };
        }
    }
}
