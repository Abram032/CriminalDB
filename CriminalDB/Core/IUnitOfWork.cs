using CriminalDB.Core.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CriminalDB.Core
{
    public interface IUnitOfWork : IDisposable
    {
        //Repositiory Interfaces fields.
        //IRepository Repo { get; }
        ICrimeRepository CrimeRepository { get; }
        ICriminalRepository CriminalRepository { get; }
        IVictimRepository VictimRepository { get; }
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class;
        int Complete();
    }
}
