using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
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
        /// Retrieve all Posts
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

            var response = new ApiResponse<IEnumerable<ProvinceDto>>(provincesDtos)
            {
                Meta = metadata
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Country(ProvinceDto provinceDto)
        {
            var province = _mapper.Map<Province>(provinceDto);
            await _provinceService.InsertProvince(province);

            provinceDto = _mapper.Map<ProvinceDto>(province);

            var response = new ApiResponse<ProvinceDto>(provinceDto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int Id, ProvinceDto provinceDto)
        {
            var province = _mapper.Map<Province>(provinceDto);
            province.Id = Id;

            var result = await _provinceService.UpdateProvince(province);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var result = await _provinceService.DeleteProvince(Id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
