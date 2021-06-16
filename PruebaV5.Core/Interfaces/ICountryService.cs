using PruebaV5.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PruebaV5.Core.Interfaces
{
    public interface ICountryService
    {
        //PagedList<Country> GetPosts(PostQueryFilter filters);
        Task<Country> GetPost(int Id);
        Task InsertPost(Country country);
        Task<bool> UpdatePost(Country country);
        Task<bool> DeletePost(int Id);
    }
}
