using System;
using System.Collections.Generic;
using System.Text;

namespace CriminalDB.Core.Utilities
{
    public interface ICrimeForm
    {
        void AddCrime();
        void Remove<TEntity>() where TEntity : class;
        void RemoveAll<TEntity>() where TEntity : class;
    }
}
