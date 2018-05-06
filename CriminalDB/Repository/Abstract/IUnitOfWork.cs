using System;
using System.Collections.Generic;
using System.Text;

namespace CriminalDB.Repository.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        //Repositiory Interfaces fields.
        //IRepository Repo { get; }
        ICrimeRepository CrimeRepository { get; }
        ICriminalRepository CriminalRepository { get; }
        ICrimeCriminalRepository CrimeCriminalRepository { get; }
        int Complete();
    }
}
