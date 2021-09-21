using System.Threading.Tasks;
using AutoMapper;
using DormFinder.Web.Auth;
using DormFinder.Web.Core.Paging;
using DormFinder.Web.Entities;
using DormFinder.Web.Entities.Identity;
using DormFinder.Web.Models;
using DormFinder.Web.Services.Intefaces;
using DormFinder.Web.Services.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using DormFinder.Web.Core.Emails;
using DormFinder.Web.Services;

namespace DormFinder.Web.Controllers
{
    [Route("api/leads")]
    [ApiController]
    [Authorize]
    public class LeadsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ILeadRepository _leadRepository;
        private readonly ILogger _logger;
        private readonly UserManager<User> _userManager;
        private readonly AccountService _accountService;
        private readonly IRoomRepository _roomRepository;
        private readonly ICurrentUser _currentUser;
        private readonly InquiryService _inquiryService;
        private readonly IBuildingRepository _buildingRepository;
        private readonly IUserRepository _userRepository;

        public LeadsController(
            IMapper mapper,
            ILeadRepository leadRepository,
            UserManager<User> userManager,
            ILogger<LeadsController> logger,
            AccountService accountService,
            IRoomRepository roomRepository,
            ICurrentUser currentUser,
            InquiryService inquiryService,
            IBuildingRepository buildingRepository,
            IUserRepository userRepository)
        {
            _mapper = mapper;
            _userManager = userManager;
            _leadRepository = leadRepository;
            _logger = logger;
            _accountService = accountService;
            _roomRepository = roomRepository;
            _currentUser = currentUser;
            _inquiryService = inquiryService;
            _buildingRepository = buildingRepository;
            _userRepository = userRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LeadModel>> GetById(int id)
        {
            var lead = await _leadRepository.GetById(id);

            return _mapper.Map<LeadModel>(lead);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<LeadModel>> Create([FromBody] AddLeadModel leadmodel)
        {
            _logger.LogInformation("Add Lead");

            var user = await _userManager.FindByEmailAsync(leadmodel.Email);

            if (user == null)
            {
                user = new User()
                {
                    Email = leadmodel.Email,
                    FirstName = leadmodel.FirstName,
                    LastName = leadmodel.LastName,
                    UserName = leadmodel.Email,
                    UserType = "Tenant",
                    Status = "Pending",
                };

                var userResult = await _userManager.CreateAsync(user);

                if (!userResult.Succeeded)
                {
                    return BadRequest(userResult.Errors);
                }

                await _accountService.GenerateEmployeesImages(user);
            }

            var lead = _mapper.Map<Lead>(leadmodel);

            var room = await _roomRepository.GetRoom(lead.RoomId);

            lead.OrganizationId = room.OrganizationId;
            lead.UserId = user.Id;

            await _leadRepository.Create(lead);

            var building = await _buildingRepository.GetById(room.BuildingId);

            var landlordUsers = await _userRepository.GetAllByOrganization(building.OrganizationId);

            var inquiry = new InquiryModel()
            {
                InquiryFullName = $"{user.FirstName} {user.LastName}",
                Address = $"{building.Address.AddressLine1} " +
                          $"{building.Address.AddressLine2} " +
                          $"{(building.Address.City != null ? building.Address.City + "," : null)} " +
                          $"{building.Address.Province} ",
                Email = lead.Email,
                Number = lead.Number,
                CreatedAt = lead.CreatedAt.ToString("dddd, dd MMMM yyyy HH:mm:ss"),
                Message = lead.Message,
                BuildingName = building.Name,
                RoomName = room.RoomName,
            };

            await _inquiryService.InquiryNotification(landlordUsers, inquiry);

            var result = _mapper.Map<LeadModel>(lead);

            return result;
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedList<LeadModel>>> List([FromQuery] PageOptions options)
        {
            _logger.LogInformation("Get Leads");

            var lead = await _leadRepository.List(options, _currentUser.OrganizationId.Value);

            return lead.Select(r => _mapper.Map<LeadModel>(r));
        }

        [HttpGet("by-user")]
        public async Task<ActionResult<PaginatedList<LeadModel>>> ListByUser([FromQuery] PageOptions options)
        {
            _logger.LogInformation("Get Leads");

            var lead = await _leadRepository.ListByUser(options, _currentUser.Id);

            return lead.Select(r => _mapper.Map<LeadModel>(r));
        }
    }
}
