using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PruebaV5.Api.Responses;
using PruebaV5.Core.CustomEntities;
using PruebaV5.Core.DTOs;
using PruebaV5.Core.Entities;
using PruebaV5.Core.Interfaces;
using PruebaV5.Core.QueryFilters;

namespace PruebaV5.Api.Controllers
{
    //[Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinceController : ControllerBase
    {
        private readonly IProvinceService _provinceService;
        private readonly IMapper _mapper;
        //private readonly IUriService _uriservice;
        public ProvinceController(IProvinceService provinceService, IMapper mapper)
        {
            _provinceService = provinceService;
            _mapper = mapper;
            //_uriservice = uriservice;
        }
        /// <summary>
        /// Retrieve all Provinces or Retrieve all Provinces By Country
        /// </summary>
        /// <param name="filters">Filters to apply</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<ProvinceDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ApiResponse<IEnumerable<ProvinceDto>>))]
        public IActionResult GetProvinces([FromQuery] ProvinceQueryFilter filters)
        {
            var provinces = _provinceService.GetProvinces(filters);
            var provincesDtos = _mapper.Map<IEnumerable<ProvinceDto>>(provinces);

            var metadata = new Metadata
            {
                TotalCount = provinces.TotalCount,
                PageSize = provinces.PageSize,
                CurrentPage = provinces.CurrentPage,
                TotalPages = provinces.TotalPages,
                HasNextPage = provinces.HasNextPage,
                HasPreviousPage = provinces.HasPreviousPage
            };

            var response = new ApiResponse<IEnumerable<ProvinceDto>>(provincesDtos, true)
            {
                Meta = metadata
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(response);
        }
        /// <summary>
        /// Add Province
        /// </summary>
        /// <param name="provinceDto">Filters to apply</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Province(ProvinceDto provinceDto)
        {
            var province = _mapper.Map<Province>(provinceDto);
            await _provinceService.InsertProvince(province);

            provinceDto = _mapper.Map<ProvinceDto>(province);

            var response = new ApiResponse<ProvinceDto>(provinceDto, true);
            return Ok(response);
        }
        /// <summary>
        /// Update Province
        /// </summary>
        /// <param name="Id">Filters to apply</param>
        /// <param name="countryId">Filters to apply</param>
        /// <param name="provinceDto">Filters to apply</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put(int Id, int countryId, ProvinceDto provinceDto)
        {
            var province = _mapper.Map<Province>(provinceDto);
            province.Id = Id;
            province.CountyId = countryId;

            var result = await _provinceService.UpdateProvince(province);
            var response = new ApiResponse<bool>(result, result);
            return Ok(response);
        }
        /// <summary>
        /// Delete Province
        /// </summary>
        /// <param name="Id">Filters to apply</param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var result = await _provinceService.DeleteProvince(Id);
            var response = new ApiResponse<bool>(result, result);
            return Ok(response);
        }
    }
}
