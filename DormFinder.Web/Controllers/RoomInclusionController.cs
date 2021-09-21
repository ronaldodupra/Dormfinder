using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DormFinder.Web.Entities;
using Microsoft.AspNetCore.Authorization;
using DormFinder.Web.Services.Intefaces;
using Microsoft.AspNetCore.Mvc;
using static DormFinder.Web.Rooms.Model.RoomDto;

namespace DormFinder.Web.Controllers
{
    [Route("api/RoomInclusion")]
    [Authorize]
    public class RoomInclusionController : Controller
    {
        private readonly IRoomInclusionRepository _roomInclusionRepository;
        private readonly IMapper _mapper;
        public RoomInclusionController(IRoomInclusionRepository roomInclusionRepository,IMapper mapper)
        {
            _roomInclusionRepository = roomInclusionRepository;
            _mapper = mapper;
        }
        [HttpGet("{id}/getInclusion")]
        public async Task<IEnumerable<RoomInclusionDto>> GetInclusion(int id)
        {
            var getRoomInclusion = await _roomInclusionRepository.GetRoomInclusion(id);

            return getRoomInclusion.Select(r => _mapper.Map<RoomInclusionDto>(r));
        }
    }
}
