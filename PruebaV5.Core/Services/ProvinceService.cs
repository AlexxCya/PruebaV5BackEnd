using Microsoft.Extensions.Options;
using PruebaV5.Core.CustomEntities;
using PruebaV5.Core.Entities;
using PruebaV5.Core.Interfaces;
using PruebaV5.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaV5.Core.Services
{
    public class ProvinceService : IProvinceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;
        public ProvinceService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
        }
        //public Task<Province> GetProvince(long Id)
        //{
        //    throw new NotImplementedException();
        //}

        public PagedList<Province> GetProvinces(ProvinceQueryFilter filters)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

            var provinces = _unitOfWork.ProvinceRepository.GetAll();

            if (filters.CountryId > 0)
                provinces = provinces.Where(x => x.CountyId == filters.CountryId);

            if (filters.Name != null)
                provinces = provinces.Where(x => x.Name.ToLower().Contains(filters.Name.ToLower()));

            var pagedProvinces = PagedList<Province>.Create(provinces, filters.PageNumber, filters.PageSize);

            return pagedProvinces;
        }

        public async Task InsertProvince(Province province)
        {
            await _unitOfWork.ProvinceRepository.Add(province);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateProvince(Province province)
        {
            _unitOfWork.ProvinceRepository.Update(province);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteProvince(int Id)
        {
            await _unitOfWork.ProvinceRepository.Delete(Id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
