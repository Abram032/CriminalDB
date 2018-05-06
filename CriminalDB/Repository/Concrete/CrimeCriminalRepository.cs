using CriminalDB.Database.Model;
using CriminalDB.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CriminalDB.Repository.Concrete
{
    public class CrimeCriminalRepository : Repository<CrimeCriminal>, ICrimeCriminalRepository
    {
        public CrimeCriminalRepository(DbContext context) : base(context)
        {

        }
    }
}
