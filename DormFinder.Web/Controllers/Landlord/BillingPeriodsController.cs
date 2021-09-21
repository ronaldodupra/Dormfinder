using System.Threading.Tasks;
using AutoMapper;
using DormFinder.Web.Auth;
using DormFinder.Web.Core.Paging;
using DormFinder.Web.Models;
using DormFinder.Web.Services.Intefaces;
using DormFinder.Web.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DormFinder.Web.Controllers.Landlord
{
    [Route("api/billing-periods")]
    [ApiController]
    [Authorize]
    [AdminOnly]
    public class BillingPeriodsController : Controller
    {
        private readonly ILogger _logger;
        private readonly BillingPeriodService _billingPeriodService;
        private readonly IBillingPeriodRepository _billingPeriodRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUser _currentUser;

        public BillingPeriodsController(
            ILogger<BillingPeriodsController> logger,
            BillingPeriodService billingPeriodService,
            IBillingPeriodRepository billingPeriodRepository,
            IMapper mapper,
            ICurrentUser currentUser)
        {
            _logger = logger;
            _billingPeriodService = billingPeriodService;
            _billingPeriodRepository = billingPeriodRepository;
            _mapper = mapper;
            _currentUser = currentUser;
        }

        [HttpPost]
        public async Task<ActionResult<BillingPeriodDto>> Create([FromBody] CreateBillingPeriodDto createBillingPeriod)
        {
            _logger.LogInformation("Add Billing Period");
            return await _billingPeriodService.Create(createBillingPeriod, _currentUser.OrganizationId.Value);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<BillingPeriodDto>> GetById(int Id)
        {
            _logger.LogInformation("Get Billing Period By ID");
            var billingPeriod = await _billingPeriodRepository.GetById(Id);
            return _mapper.Map<BillingPeriodDto>(billingPeriod);
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedList<BillingPeriodDto>>> List([FromQuery] PageOptions options)
        {
            _logger.LogInformation("Get Billing Period List");
            var billingPeriod = await _billingPeriodRepository.List(options, _currentUser.OrganizationId.Value);
            return billingPeriod.Select(r => _mapper.Map<BillingPeriodDto>(r));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BillingPeriodDto>> Update([FromBody] CreateBillingPeriodDto createBillingPeriod, int id)
        {
            _logger.LogInformation("Add Billing Period");
            return await _billingPeriodService.Update(createBillingPeriod, _currentUser.OrganizationId.Value, id);
        }
    }
}
