using System;
using System.Collections.Generic;
using CriminalDB.Core.DataModels;

namespace CriminalDB.Core.EntityValidator
{
    public interface IEntityValidator
    {
         bool Validate<TEntity>(TEntity entity) where TEntity : class;
         bool ValidateDates(DateTime t1);
         bool ValidateDates(DateTime t1, DateTime t2);
    }
}