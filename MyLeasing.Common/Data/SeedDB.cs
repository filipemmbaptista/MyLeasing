using MyLeasing.Common.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeasing.Common.Data
{
    public class SeedDB
    {
        private readonly DataContext _context;
        private Random _random;

        public SeedDB(DataContext context)
        {
            _context = context;
            _random = new Random();
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            if (!_context.Owners.Any())
            {
                AddOwner("João", "Rodrigues");
                AddOwner("Maria", "Callas");
                AddOwner("Maria", "Lopes");
                AddOwner("Rui", "Costa");
                AddOwner("Rafael", "Santos");
                AddOwner("Filipe", "Baptista");
                AddOwner("Luís", "Patrício");
                AddOwner("Ruben", "Mateus");
                AddOwner("Catarina", "Esperanca");
                AddOwner("Ricardo", "Salgado");
                await _context.SaveChangesAsync();
            }
        }

        private void AddOwner(string fname, string lname)
        {
            _context.Owners.Add(new Owner
            {
                Document = _random.Next(100000000),
                FirstName = fname,
                LastName = lname,
            });
        }
    }
}
