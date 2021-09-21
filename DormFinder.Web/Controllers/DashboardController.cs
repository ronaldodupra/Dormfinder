using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DormFinder.Web.Auth;
using DormFinder.Web.Dashboard.Model;
using DormFinder.Web.Services.Intefaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DormFinder.Web.Controllers
{
    [Route("api/dashboard")]
    [ApiController]
    [Authorize]
    
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardRepository _dashboardRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUser _currentUser;
        public DashboardController(IDashboardRepository dashboardRepository,
            IMapper mapper,
            ICurrentUser currentUser)
        {
            _dashboardRepository = dashboardRepository;
            _mapper = mapper;
            _currentUser = currentUser;
        }

        [HttpGet]
        public async Task<IEnumerable<DashboardDto>> RoomChart()
        {
            var chart =await _dashboardRepository.RoomChart(_currentUser.OrganizationId.Value);
            return chart.ToList().Select(x => _mapper.Map<DashboardDto>(x));
        }
        [HttpGet("{search}")]
        public async Task<IEnumerable<DashboardDto>> RoomChartFilter(string search)
        {
            var chart = await _dashboardRepository.RoomChartFilter(search, _currentUser.OrganizationId.Value);
            return chart.ToList().Select(x => _mapper.Map<DashboardDto>(x));
        }
    }
}
