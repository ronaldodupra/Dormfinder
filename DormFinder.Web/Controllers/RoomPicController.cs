using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DormFinder.Web.Services.Intefaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DormFinder.Web.Controllers
{
    [Route("api/roompic")]
    [ApiController]
    [Authorize]
    public class RoomPicController : ControllerBase
    {
        private readonly IRoomPicRepository _roomPicRepository;
        public RoomPicController(IRoomPicRepository roomPicRepository)
        {
            _roomPicRepository = roomPicRepository;
        }
        [HttpPut("{roomId}/thumbnail")]
        public async Task<IActionResult> UpdateThumbnail([FromBody] int fileId, int roomId)
        {
            await _roomPicRepository.SetUpThumbNail(roomId, fileId);
            return Ok();
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> RemoveImage(int Id)
        {
            await _roomPicRepository.Remove(Id);
            return Ok();
        }
    }
}
