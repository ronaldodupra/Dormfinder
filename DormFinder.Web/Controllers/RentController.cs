using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DormFinder.Web.Rooms.Model;
using DormFinder.Web.Services.Intefaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DormFinder.Web.Controllers
{
    [Route("api/rent")]
    [ApiController]
    public class RentController : ControllerBase
    {
        public readonly IMapper _mapper;
        public readonly IRoomRepository _roomRepository;
        public RentController(IMapper mapper,IRoomRepository roomRepository)
        {
            _mapper = mapper;
            _roomRepository = roomRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<RentRoomDto>> GetRooms()
        {
            var rentRoomList = await _roomRepository.RoomToRentList();
            return rentRoomList.Select(r => _mapper.Map<RentRoomDto>(r));
        }
        [HttpGet("location={location}&minprice={minprice}&maxprice={maxprice}")]
        public async Task<IEnumerable<RentRoomDto>> SearchRoom(string location,int minPrice,int maxPrice)
        {
            var rentRoomList = await _roomRepository.SearchRent(location,minPrice,maxPrice);
            return rentRoomList.Select(r => _mapper.Map<RentRoomDto>(r));
        }
    }
}
