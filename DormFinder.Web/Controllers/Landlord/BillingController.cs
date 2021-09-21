using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DormFinder.Web.Auth;
using DormFinder.Web.Billings.Utilities.Model;
using DormFinder.Web.Billings.Utilities.Services;
using DormFinder.Web.Core.Paging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DormFinder.Web.Controllers.Landlord
{
    [Route("api/billings")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    [AdminOnly]
    public class BillingController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly ICurrentUser _currentUser;
        private readonly UtilityService _utilityService;
        public BillingController(
            IMapper mapper,
            ILogger<BillingController> logger,
            ICurrentUser currentUser,
            UtilityService utilityService)
        {
            _mapper = mapper;
            _logger = logger;
            _currentUser = currentUser;
            _utilityService = utilityService;
        }

        /// <summary>
        /// List all water Reading
        /// </summary>
        /// <returns></returns>
        [HttpGet("water")]
        public async Task<ActionResult<PaginatedList<UtilityReadingDto>>> GetUtilitiesReadingWater([FromQuery] PageOptions options)
        {
            _logger.LogInformation("Get Utilities");

            int waterType = 1;

            return await _utilityService.GetUtilitiesReadingsCurrAndPrevMonth(options, _currentUser.OrganizationId.Value, waterType);

            //return buildings.Select(r => _mapper.Map<BuildingDto>(r));
        }

        /// <summary>
        /// List all water Reading
        /// </summary>
        /// <returns></returns>
        [HttpGet("electricity")]
        public async Task<ActionResult<PaginatedList<UtilityReadingDto>>> GetUtilitiesReadingElectricity([FromQuery] PageOptions options)
        {
            _logger.LogInformation("Get Utilities");

            int electricityType = 2;

            return await _utilityService.GetUtilitiesReadingsCurrAndPrevMonth(options, _currentUser.OrganizationId.Value, electricityType);

            //return buildings.Select(r => _mapper.Map<BuildingDto>(r));
        }

        /// <summary>
        /// Update a building
        /// </summary>
        /// <param name="id"></param>
        /// <param name="readingDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromBody] IEnumerable<UtilityReadingDto> readingDto)
        {
            _logger.LogInformation("Update utility readings");
            await _utilityService.SaveChanges(_currentUser.OrganizationId.Value, readingDto);

            return Ok();
        }
    }
}
