using PruebaV5.Core.Entities;
using PruebaV5.Core.Interfaces;
using PruebaV5.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PruebaV5.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PruebaV5BDContext _context;
        private readonly IRepository<Country> _countryRepository;
        private readonly IRepository<Province> _provinceRepository;

        public UnitOfWork(PruebaV5BDContext context)
        {
            _context = context;
        }
        public IRepository<Country> CountryRepository => _countryRepository ?? new BaseRepository<Country>(_context);

        public IRepository<Province> ProvinceRepository => _provinceRepository ?? new BaseRepository<Province>(_context);

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
