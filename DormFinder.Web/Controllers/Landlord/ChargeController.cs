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

namespace DormFinder.Web.Controllers
{
    [Route("api/charges")]
    [ApiController]
    [Authorize]
    [AdminOnly]
    public class ChargeController : Controller
    {
        private readonly IChargeRepository _chargeRepository;
        private readonly ChargeService _chargeService;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly ICurrentUser _currentUser;
        public ChargeController(IChargeRepository chargeRepository,
            ChargeService chargeService,
            ILogger<ChargeController> logger,
            IMapper mapper,
            ICurrentUser currentUser)
        {
            _chargeRepository = chargeRepository;
            _chargeService = chargeService;
            _logger = logger;
            _mapper = mapper;
            _currentUser = currentUser;
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedList<ChargeDto>>> GetCharges([FromQuery] PageOptions options)
        {
            _logger.LogInformation("Get Charges");

            var charges = await _chargeRepository.GetCharges(options, _currentUser.OrganizationId.Value);

            return charges.Select(r => _mapper.Map<ChargeDto>(r));
        }

        [HttpGet("byCompany/{companyId}")]
        public async Task<IActionResult> GetChargesByCompany(string companyId)
        {
            _logger.LogInformation("Get Charges by Company");
            return Ok(await _chargeRepository.GetChargesByCompany(companyId));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ChargeDto>> GetById(int id)
        {
            _logger.LogInformation("Get charge with id #{id}", id);

            var charge = await _chargeRepository.GetById(id);

            if (charge is null)
            {
                return NotFound();
            }
            else
            {
                return _mapper.Map<ChargeDto>(charge);
            }
        }

        [HttpPost("changeOrder")]
        public async Task<IActionResult> ChangeOrder([FromBody] List<ChargeOrder> _chargeOrders)
        {
            _logger.LogInformation("Charge Change Order");
            if (ModelState.IsValid)
            {
                await _chargeRepository.ChangeOrder(_chargeOrders);
                return Ok();
            }
            else
            {
                _logger.LogWarning("Charge change order model is not valid");
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult<ChargeDto>> Create(string companyId, [FromBody] CreateChargeDto chargeDto)
        {
            _logger.LogInformation("Add Charge");

            return await _chargeService.Create(chargeDto, _currentUser.OrganizationId.Value);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ChargeDto>> UpdateCharge(int id, [FromBody] CreateChargeDto chargeDto)
        {
            _logger.LogInformation("Update Charge with id #{id}", id);

            return await _chargeService.Update(id, chargeDto);
        }
    }
}
