using System.Threading.Tasks;
using AutoMapper;
using DormFinder.Web.Core.Paging;
using DormFinder.Web.Entities;
using DormFinder.Web.Models;
using DormFinder.Web.Services.Intefaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using DormFinder.Web.Auth;

namespace DormFinder.Web.Controllers
{
    [Route("api/contracts")]
    [ApiController]
    [Authorize]
    public class ContractController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IContractRepository _contractRepository;
        private readonly ITenantRepository _tenantRepository;
        private readonly ILogger _logger;
        private readonly ICurrentUser _currentUser;
        private readonly IBillingPeriodRepository _billingPeriodRepository;

        public ContractController(
            IMapper mapper,
            IContractRepository contractRepository,
            ITenantRepository tenantRepository,
            ILogger<ContractController> logger,
            ICurrentUser currentUser,
            IBillingPeriodRepository billingPeriodRepository)
        {
            _mapper = mapper;
            _contractRepository = contractRepository;
            _tenantRepository = tenantRepository;
            _logger = logger;
            _currentUser = currentUser;
            _billingPeriodRepository = billingPeriodRepository;
        }

        [HttpPost]
        [AdminOnly]
        public async Task<ActionResult<ContractModel>> Create(int companyId, [FromBody] AddContractModel contractModel)
        {
            _logger.LogInformation("Add Contract");

            var contract = _mapper.Map<Contract>(contractModel);

            contract.OrganizationId = _currentUser.OrganizationId.Value;

            await _contractRepository.Create(companyId, contract);

            var result = _mapper.Map<ContractModel>(contract);

            return result;
        }

        [HttpGet("{id}")]
        [AdminOnly]
        public async Task<ActionResult<ContractModel>> GetById(int id)
        {
            _logger.LogInformation("Get Contract by Id");
            var contract = await _contractRepository.GetById(id);

            return _mapper.Map<ContractModel>(contract);
        }

        [HttpPut("{contractId}")]
        [AdminOnly]
        public async Task<ActionResult<ContractModel>> Update(int contractId, [FromBody] UpdateContractModel contractModel)
        {
            _logger.LogInformation("Update Contract");

            await _contractRepository.RemoveContractCharge(contractId);

            var contract = await _contractRepository.GetById(contractId);

            _mapper.Map(contractModel, contract);

            await _contractRepository.UpdateContract();

            var result = _mapper.Map<ContractModel>(contract);

            return result;
        }

        [HttpPost("{contractId}/approve")]
        public async Task<ActionResult> Approve(int contractId)
        {
            var contract = await _contractRepository.GetById(contractId);

            contract.Approve = true;

            await _contractRepository.SaveChanges();

            var tenant = new Tenant()
            {
                ContractId = contract.Id,
                RoomId = contract.RoomId,
                UserId = contract.UserId,
                OrganizationId = contract.OrganizationId
                
            };

            await _tenantRepository.Create(tenant);

            return Ok();
        }

        [HttpGet("byBillingPeriodId/{id}")]
        [AdminOnly]
        public async Task<ActionResult<PaginatedList<ContractModel>>> List([FromQuery] PageOptions options,int id)
        {
            _logger.LogInformation("Get Contracts");
            var billingPeriod=await _billingPeriodRepository.GetById(id);
            var contracts = await _contractRepository.List(options,_currentUser.OrganizationId.Value, billingPeriod.BeginDate, billingPeriod.EndDate);

            return contracts.Select(r => _mapper.Map<ContractModel>(r));

        }

        [HttpGet("{roomId}/getContractsByRoom")]
        [AdminOnly]
        public async Task<IEnumerable<ContractModel>> ContractByRoom(int roomId)
        {
            _logger.LogInformation("Get Contracts By Room");

            var contracts = await _contractRepository.ListByRoom(roomId);

            return contracts.ToList().Select(x => _mapper.Map<ContractModel>(x));
        }
    }
}
