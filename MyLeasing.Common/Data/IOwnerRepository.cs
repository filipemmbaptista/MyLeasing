﻿using MyLeasing.Common.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLeasing.Common.Data
{
    public interface IOwnerRepository : IGenericRepository<Owner>
    {
        public IQueryable GetAllWithUsers();
    }
}
