using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DormFinder.Web.Buildings.Models;
using DormFinder.Web.Entities;
using DormFinder.Web.Rooms.Model;
using DormFinder.Web.Services.Intefaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DormFinder.Web.Controllers
{
    [Route("api/property")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPropertyRepository _propertyRepository;
        public PropertyController(IMapper mapper, IPropertyRepository propertyRepository)
        {
            _mapper = mapper;
            _propertyRepository = propertyRepository;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomPropertyDto>> GetProperty(int id)
        {
            var property = await _propertyRepository.GetProperty(id);
            return _mapper.Map<RoomPropertyDto>(property);
        }
        [HttpGet("{id}/properties")]
        public async Task<IEnumerable<BuildingPropertyDto>> SimilarProperties(int id)
        {
            var property = await _propertyRepository.SimilarProperties(id);
            return property.Select(x => _mapper.Map<BuildingPropertyDto>(x));
        }
        [HttpGet("filter={location}")]
        public async Task<IEnumerable<BuildingPropertyDto>> FilterLocation(string location)
        {

            var search = await _propertyRepository.SearchProperty(location);
            return search.Select(x => _mapper.Map<BuildingPropertyDto>(x));
        }
    }
}
