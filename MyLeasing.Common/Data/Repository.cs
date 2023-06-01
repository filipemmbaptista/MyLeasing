using MyLeasing.Common.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeasing.Common.Data
{
    public class Repository:IRepository
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }

        public void AddOwner(Owner owner)
        {
            _context.Owners.Add(owner);
        }

        public Owner GetOwner(int id)
        {
            return _context.Owners.Find(id);
        }

        public IEnumerable<Owner> GetOwners()
        {
            return _context.Owners.OrderBy(x => x.FirstName);
        }

        public bool OwnerExist(int id)
        {
            return _context.Owners.Any(x => x.Id == id);
        }

        public void RemoveOwner(Owner owner)
        {
            _context.Owners.Remove(owner);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void UpdaterOwner(Owner owner)
        {
            _context.Owners.Update(owner);
        }
    }
}
