using CriminalDB.Core.DataModels;
using CriminalDB.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CriminalDB.Persistence.Repository
{
    public class CrimeCriminalRepository : Repository<CrimeCriminal>, ICrimeCriminalRepository
    {
        public CrimeCriminalRepository(DbContext context) : base(context)
        {

        }
    }
}
