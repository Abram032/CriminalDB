using CriminalDB.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CriminalDB.Repository.Concrete
{
    class UnitOfWork : IUnitOfWork
    {
        private DbContext _context;

        //Include interface fields here.
        //public IRepository Repo { get; private set; }

        public ICrimeRepository CrimeRepository { get; private set; }
        public ICriminalRepository CriminalRepository { get; private set; }
        public ICrimeCriminalRepository CrimeCriminalRepository { get; private set; }


        public UnitOfWork(DbContext context)
        {
            _context = context;
            CrimeRepository = new CrimeRepository(_context);
            CriminalRepository = new CriminalRepository(_context);
            CrimeCriminalRepository = new CrimeCriminalRepository(_context);
            //Classes use same context
            //Repo = new Repository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
