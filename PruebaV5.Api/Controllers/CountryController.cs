using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PruebaV5.Api.Responses;
using PruebaV5.Core.CustomEntities;
using PruebaV5.Core.DTOs;
using PruebaV5.Core.Entities;
using PruebaV5.Core.Interfaces;
using PruebaV5.Core.QueryFilters;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace PruebaV5.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;
        private readonly IMapper _mapper;
        //private readonly IUriService _uriservice;
        public CountryController(ICountryService countryService, IMapper mapper)
        {
            _countryService = countryService;
            _mapper = mapper;
            //_uriservice = uriservice;
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCountry(int Id)
        {
            var country = await _countryService.GetCountry(Id);
            var countryDto = _mapper.Map<CountryDto>(country);
            var response = new ApiResponse<CountryDto>(countryDto);
            return Ok(response);
        }
        /// <summary>
        /// Retrieve all Posts
        /// </summary>
        /// <param name="filters">Filters to apply</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<CountryDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ApiResponse<IEnumerable<CountryDto>>))]
        public IActionResult GetCountries([FromQuery] CountryQueryFilter filters)
        {
            var countries = _countryService.GetCountries(filters);
            var countriesDtos = _mapper.Map<IEnumerable<CountryDto>>(countries);
            
            var metadata = new Metadata
            {
                TotalCount = countries.TotalCount,
                PageSize = countries.PageSize,
                CurrentPage = countries.CurrentPage,
                TotalPages = countries.TotalPages,
                HasNextPage = countries.HasNextPage,
                HasPreviousPage = countries.HasPreviousPage
            };

            var response = new ApiResponse<IEnumerable<CountryDto>>(countriesDtos)
            {
                Meta = metadata
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Country(CountryDto countryDto)
        {
            var country = _mapper.Map<Country>(countryDto);
            await _countryService.InsertCountry(country);

            countryDto = _mapper.Map<CountryDto>(country);

            var response = new ApiResponse<CountryDto>(countryDto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int Id, CountryDto countryDto)
        {
            var country = _mapper.Map<Country>(countryDto);
            country.Id = Id;

            var result = await _countryService.UpdateCountry(country);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var result = await _countryService.DeleteCountry(Id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
