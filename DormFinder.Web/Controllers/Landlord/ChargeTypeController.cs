using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DormFinder.Web.Charges.Models;
using DormFinder.Web.Charges.Services;
using DormFinder.Web.Core.Paging;
using DormFinder.Web.Entities;
using DormFinder.Web.Models;
using DormFinder.Web.Services.Intefaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using DormFinder.Web.Auth;
using DormFinder.Web.ChargeTypes.Models;

namespace DormFinder.Web.Controllers.Landlord
{
    [Route("api/chargeTypes")]
    [ApiController]
    [Authorize]
    [AdminOnly]
    public class ChargeTypeController : Controller
    {

        private readonly IChargeTypeRepository _chargeTypeRepository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        public ChargeTypeController(ILogger<ChargeTypeController> logger,
            IChargeTypeRepository chargeTypeRepository,
            IMapper mapper)
        {
            _chargeTypeRepository = chargeTypeRepository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedList<ChargeTypeDto>>> GetChargeTypes([FromQuery] PageOptions options)
        {
            _logger.LogInformation("Get Charge Types");

            var chargeTypes = await _chargeTypeRepository.GetChargeTypes(options);

            return chargeTypes.Select(r => _mapper.Map<ChargeTypeDto>(r));
        }
    }
}
