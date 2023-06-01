using MyLeasing.Common.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeasing.Common.Data
{
    public interface IRepository
    {
        void AddOwner(Owner owner);

        Owner GetOwner(int id);

        IEnumerable<Owner> GetOwners();

        bool OwnerExist(int id);

        void RemoveOwner(Owner owner);

        Task<bool> SaveAllAsync();

        void UpdaterOwner(Owner owner);
    }
}
