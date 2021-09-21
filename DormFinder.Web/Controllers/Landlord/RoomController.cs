using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DormFinder.Web.Auth;
using DormFinder.Web.Buildings.Models;
using DormFinder.Web.Core.Files;
using DormFinder.Web.Core.Paging;
using DormFinder.Web.Entities;
using DormFinder.Web.Models;
using DormFinder.Web.Rooms.Model;
using DormFinder.Web.Rooms.Models;
using DormFinder.Web.Rooms.Service;
using DormFinder.Web.Services;
using DormFinder.Web.Services.Intefaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace DormFinder.Web.Controllers
{
    [Route("api/rooms")]
    [ApiController]
    [Authorize]
    [AdminOnly]
    public class RoomController : Controller
    {
        private readonly IRoomRepository _roomRepository;

        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly RoomService _roomService;
        private readonly ICurrentUser _currentUser;

        public RoomController(IRoomRepository roomRepository,
            ILogger<RoomController> logger,
            IMapper mapper,
            RoomService roomService,
            IRoomPicRepository roomPicRepository,
            ICurrentUser currentUser)
        {
            _roomRepository = roomRepository;
            _logger = logger;
            _mapper = mapper;
            _roomService = roomService;
            _currentUser = currentUser;
        }

        [HttpGet("byBuildingFloor/{buildingId}/{floorId}")]
        public async Task<IActionResult> GetRooms(string buildingId, string floorId)
        {
            _logger.LogInformation("Get Rooms by Building by Floor");
            return Ok(await _roomRepository.GetRoomsByFloors(buildingId, floorId));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoomDto>> GetRoom(int id)
        {
            _logger.LogInformation("Get Room by id");
            var room = await _roomRepository.GetRoom(id);
            return _mapper.Map<RoomDto>(room);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditRoom(int id, [FromBody] CreateRoomDto _model)
        {
            _logger.LogInformation("Update Room");
            //if (ModelState.IsValid)
            //{
            //    return Ok();
            //}
            _logger.LogWarning("Update Room model is not valid");
            return Ok(await _roomService.UpdateRoom(id, _model));
        }

        [HttpGet("byContract/{contractId}")]
        public async Task<IActionResult> GetByContract(string contractId)
        {
            _logger.LogInformation("Get by Contract");
            return Ok(await _roomRepository.GetByContract(contractId));
        }

        [HttpPost]
        public async Task<ActionResult<RoomDto>> Create([FromBody] CreateRoomDto model)
        {
            var room = await _roomService.AddRoom(model, _currentUser.OrganizationId.Value);
            return _mapper.Map<RoomDto>(room);
        }

        [HttpGet("byBuildingFloor")]
        public async Task<ActionResult<PaginatedList<RoomDto>>> GetRooms([FromQuery] PageOptions options)
        {
            _logger.LogInformation("Get Rooms");

            var rooms = await _roomRepository.GetRooms(options, _currentUser.OrganizationId.Value);

            return rooms.Select(r => _mapper.Map<RoomDto>(r));
        }

        [HttpGet("rooms")]
        public async Task<IEnumerable<RoomDto>> GetRooms()
        {
            var rooms = await _roomRepository.GetRoomList(_currentUser.OrganizationId.Value);

            return rooms.Select(r => _mapper.Map<RoomDto>(r));
        }
    }
}
