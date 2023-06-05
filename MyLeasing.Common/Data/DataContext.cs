using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyLeasing.Common.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeasing.Common.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DbSet<Owner> Owners { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }
}
