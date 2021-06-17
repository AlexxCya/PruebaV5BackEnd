using PruebaV5.Core.CustomEntities;
using PruebaV5.Core.Entities;
using PruebaV5.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PruebaV5.Core.Interfaces
{
    public interface IProvinceService
    {
        PagedList<Province> GetProvinces(ProvinceQueryFilter filters);
        //Task<Province> GetProvince(long Id);
        Task InsertProvince(Province province);
        Task<bool> UpdateProvince(Province province);
        Task<bool> DeleteProvince(int Id);
    }
}
