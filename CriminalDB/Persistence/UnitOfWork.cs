using CriminalDB.Core.Repository;
using CriminalDB.Persistence.Repository;
using CriminalDB.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CriminalDB.Persistence
{
    class UnitOfWork : IUnitOfWork
    {
        private DbContext _context;

        //Include IRepository fields here.

        public ICrimeRepository CrimeRepository { get; private set; }
        public ICriminalRepository CriminalRepository { get; private set; }
        public ICrimeCriminalRepository CrimeCriminalRepository { get; private set; }
        public IVictimRepository VictimRepository { get; private set; }
        public ICrimeVictimRepository CrimeVictimRepository { get; private set; }


        public UnitOfWork(DbContext context)
        {
            //Inject context
            //All repositories use same context

            _context = context;
            CrimeRepository = new CrimeRepository(_context);
            CriminalRepository = new CriminalRepository(_context);
            CrimeCriminalRepository = new CrimeCriminalRepository(_context);
            VictimRepository = new VictimRepository(_context);
            CrimeVictimRepository = new CrimeVictimRepository(_context);
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
