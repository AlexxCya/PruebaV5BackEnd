using Microsoft.Extensions.Options;
using PruebaV5.Core.CustomEntities;
using PruebaV5.Core.Entities;
using PruebaV5.Core.Interfaces;
using PruebaV5.Core.QueryFilters;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaV5.Core.Services
{
    public class CountryService : ICountryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;
        public CountryService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
        }
        public async Task<Country> GetCountry(int Id)
        {
            return await _unitOfWork.CountryRepository.GetById(Id);
        }
        public PagedList<Country> GetCountries(CountryQueryFilter filters)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

            var countries = _unitOfWork.CountryRepository.GetAll();

            if (filters.Name != null)
                countries = countries.Where(x => x.Name.ToLower().Contains(filters.Name.ToLower()));

            if (filters.Alpha2Code != null)
                countries = countries.Where(x => x.Alpha2Code == filters.Alpha2Code);

            var pagedCountries = PagedList<Country>.Create(countries, filters.PageNumber, filters.PageSize);

            return pagedCountries;
        }

        public Task InsertCountry(Country country)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateCountry(Country country)
        {
            _unitOfWork.CountryRepository.Update(country);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteCountry(int Id)
        {
            await _unitOfWork.CountryRepository.Delete(Id);
            return true;
        }
    }
}
