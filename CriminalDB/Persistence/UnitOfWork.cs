using CriminalDB.Core.Repository;
using CriminalDB.Persistence.Repository;
using CriminalDB.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CriminalDB.Persistence
{
    class UnitOfWork : IUnitOfWork
    {
        private DbContext _context;

        public ICrimeRepository CrimeRepository { get; private set; }
        public ICriminalRepository CriminalRepository { get; private set; }
        public ICrimeCriminalRepository CrimeCriminalRepository { get; private set; }
        public IVictimRepository VictimRepository { get; private set; }
        public ICrimeVictimRepository CrimeVictimRepository { get; private set; }

        private Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public UnitOfWork(DbContext context)
        {
            _context = context;

            CrimeRepository = new CrimeRepository(_context);
            CriminalRepository = new CriminalRepository(_context);
            CrimeCriminalRepository = new CrimeCriminalRepository(_context);
            VictimRepository = new VictimRepository(_context);
            CrimeVictimRepository = new CrimeVictimRepository(_context);
        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if(repositories.Keys.Contains(typeof(TEntity)) == true)
                return repositories[typeof(TEntity)] as IGenericRepository<TEntity>;

            IGenericRepository<TEntity> repository = new GenericRepository<TEntity>(_context);
            repositories.Add(typeof(TEntity), repository);
            return repository;
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
