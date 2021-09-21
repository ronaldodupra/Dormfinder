using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DormFinder.Web.Models;
using DormFinder.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace DormFinder.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OptionsController : ControllerBase
    {
        private readonly IOptionsRepository _optionsRepository;
        private readonly IMapper _mapper;

        public OptionsController(IOptionsRepository optionsRepository, IMapper mapper)
        {
            _optionsRepository = optionsRepository;
            _mapper = mapper;
        }

        [HttpGet("cities")]
        public async Task<ActionResult<ICollection<CityDto>>> GetCities()
        {
            var cities = await _optionsRepository.GetCities();
            var dtos = cities.Select(t => _mapper.Map<CityDto>(t)).ToList();

            return dtos;
        }

        [HttpGet("provinces")]
        public async Task<ActionResult<ICollection<ProvinceDto>>> GetProvinces()
        {
            var provinces = await _optionsRepository.GetProvinces();
            var dtos = provinces.Select(t => _mapper.Map<ProvinceDto>(t)).ToList();

            return dtos;
        }

        [HttpGet("address")]
        [AllowAnonymous]
        public async Task<List<AddressViewModel>> GetAddress()
        {
            var getAddress = await _optionsRepository.GetAddress();
            return getAddress.GroupBy(item => new { city = item.City?.ToLower(), province = item.Province?.ToLower() }).Select(item => new AddressViewModel
            {
                AddressName = $"{item.FirstOrDefault()?.Province} {item.FirstOrDefault()?.City}",
                City = item.FirstOrDefault()?.City,
                Province = item.FirstOrDefault()?.Province,
                Count = item.Count(),
            })
            .ToList();

        }
    }
}
