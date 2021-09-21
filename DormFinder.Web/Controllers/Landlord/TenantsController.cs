using System.Threading.Tasks;
using AutoMapper;
using DormFinder.Web.Core.Paging;
using DormFinder.Web.Entities;
using DormFinder.Web.Models;
using DormFinder.Web.Services.Intefaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using DormFinder.Web.Auth;

namespace DormFinder.Web.Controllers
{
    [Route("api/tenants")]
    [ApiController]
    [Authorize]
    [AdminOnly]
    public class TenantsController : ControllerBase
    {
        private readonly ITenantRepository _tenantRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUser _currentUser;

        public TenantsController(ITenantRepository tenantRepository,
            IMapper mapper,
            ICurrentUser currentUser)
        {
            _tenantRepository = tenantRepository;
            _mapper = mapper;
            _currentUser = currentUser;
        }

        /// <summary>
        /// Get tenant by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<TenantDto>> GetById(int id)
        {
            var tenant = await _tenantRepository.GetById(id);

            if (tenant is null)
            {
                return NotFound();
            }

            return _mapper.Map<TenantDto>(tenant);
        }

        /// <summary>
        /// Create a tenant
        /// </summary>
        /// <param name="createDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<TenantDto>> Create([FromBody] CreateTenantDto createDto)
        {
            var tenant = _mapper.Map<Tenant>(createDto);

            tenant.OrganizationId = _currentUser.OrganizationId.Value;

            await _tenantRepository.Create(tenant);

            return _mapper.Map<TenantDto>(tenant);
        }

        /// <summary>
        /// List all tenants
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<PaginatedList<TenantDto>>> List([FromQuery] PageOptions options)
        {
            var tenants = await _tenantRepository.List(options, _currentUser.OrganizationId.Value);
            var dtos = tenants.Select(t => _mapper.Map<TenantDto>(t));

            return dtos;
        }

        [HttpGet("{roomId}/getTenantsByRoom")]
        public async Task<IEnumerable<TenantContractDto>> TenantByRoom(int roomId)
        {
            var contracts = await _tenantRepository.ListByRoom(roomId);

            return contracts.ToList().Select(x => _mapper.Map<TenantContractDto>(x));
        }
    }
}
