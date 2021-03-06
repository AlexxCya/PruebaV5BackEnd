using PruebaV5.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaV5.Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        Task<T> GetById(long id);
        Task Add(T entity);
        void Update(T entity);
        Task Delete(int id);
    }
}
