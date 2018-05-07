using CriminalDB.Core.DataModels;
using CriminalDB.Core.Repository;
using CriminalDB.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CriminalDB.Persistence.Repository
{
    public class CriminalRepository: Repository<Criminal>, ICriminalRepository
    {
        public CriminalRepository(DbContext context) : base(context)
        {

        }
    }
}
