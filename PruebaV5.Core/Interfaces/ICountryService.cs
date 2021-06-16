using PruebaV5.Core.CustomEntities;
using PruebaV5.Core.Entities;
using PruebaV5.Core.QueryFilters;
using System.Threading.Tasks;

namespace PruebaV5.Core.Interfaces
{
    public interface ICountryService
    {
        PagedList<Country> GetCountries(CountryQueryFilter filters);
        Task<Country> GetCountry(int Id);
        Task InsertCountry(Country country);
        Task<bool> UpdateCountry(Country country);
        Task<bool> DeleteCountry(int Id);
    }
}
