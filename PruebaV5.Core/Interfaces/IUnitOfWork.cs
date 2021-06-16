using PruebaV5.Core.Entities;
using System;
using System.Threading.Tasks;

namespace PruebaV5.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Country> CountryRepository { get;}
        IRepository<Province> ProvinceRepository { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
