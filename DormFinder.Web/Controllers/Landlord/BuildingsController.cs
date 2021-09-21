using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DormFinder.Web.Auth;
using DormFinder.Web.Buildings.Models;
using DormFinder.Web.Buildings.Services;
using DormFinder.Web.Core.Paging;
using DormFinder.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace DormFinder.Web.Controllers
{
    [Route("api/buildings")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    [AdminOnly]
    public class BuildingsController : Controller
    {
        private readonly IBuildingRepository _buildingRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly BuildingService _buildingService;
        private readonly ICurrentUser _currentUser;

        public BuildingsController(
            IBuildingRepository buildingRepository,
            IMapper mapper,
            ILogger<BuildingsController> logger,
            BuildingService buildingService,
            ICurrentUser currentUser)
        {
            _buildingRepository = buildingRepository;
            _mapper = mapper;
            _logger = logger;
            _buildingService = buildingService;
            _currentUser = currentUser;
        }

        /// <summary>
        /// Create a building
        /// </summary>
        /// <param name="createDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<BuildingDto>> Create([FromBody] CreateBuildingDto createDto)
        {
            _logger.LogInformation("Add Building");

            return await _buildingService.Create(createDto, _currentUser.OrganizationId.Value);
        }

        /// <summary>
        /// Retrieve a building
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<BuildingDto>> GetById(int id)
        {
            _logger.LogInformation("Get building with id #{id}", id);
            var building = await _buildingRepository.GetById(id);

            if (building is null)
            {
                return NotFound();
            }
            else
            {
                return _mapper.Map<BuildingDto>(building);
            }
        }

        /// <summary>
        /// Update a building
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<BuildingDto>> Update(int id, [FromBody] UpdateBuildingDto updateDto)
        {
            _logger.LogInformation("Update building with id #{id}", id);
            return await _buildingService.Update(id, updateDto);
        }

        /// <summary>
        /// List all buildings
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<PaginatedList<BuildingDto>>> List([FromQuery] PageOptions options)
        {
            _logger.LogInformation("Get Buildings");

            var buildings = await _buildingRepository.List(options, _currentUser.OrganizationId.Value);

            return buildings.Select(r => _mapper.Map<BuildingDto>(r));
        }

        /// <summary>
        /// Get all building types
        /// </summary>
        /// <returns></returns>
        [HttpGet("buildingType")]
        public async Task<ActionResult<List<BuildingTypeDto>>> TypeList()
        {
            var list = await _buildingRepository.TypeList();

            return _mapper.Map<List<BuildingTypeDto>>(list);
        }

    }
}
