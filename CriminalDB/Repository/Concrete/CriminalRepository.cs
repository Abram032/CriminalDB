using CriminalDB.Database.Model;
using CriminalDB.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CriminalDB.Repository.Concrete
{
    public class CriminalRepository: Repository<Criminal>, ICriminalRepository
    {
        public CriminalRepository(DbContext context) : base(context)
        {

        }
    }
}
