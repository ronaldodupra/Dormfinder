using AutoMapper;
using DormFinder.Web.Entities;
using DormFinder.Web.Models;
using DormFinder.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace DormFinder.Web.Controllers
{
    [Route("api/bedspaces")]
    [Authorize]
    public class BedspaceController : Controller
    {
        private readonly IBedspaceRepository _bedspaceRepository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public BedspaceController(IBedspaceRepository bedspaceRepository, ILogger<BedspaceController> logger,IMapper mapper)
        {
            _bedspaceRepository = bedspaceRepository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("{roomId}/roomBed")]
        public async Task<IEnumerable<BedspaceViewModel>> GetBedspaces(int roomId)
        {
            _logger.LogInformation("Get Bedspaces by Room");
            var bedSpace=await _bedspaceRepository.GetAllByRoom(roomId);
            return bedSpace.ToList().Select(x=> _mapper.Map<BedspaceViewModel>(x));
        }

        [HttpGet("byRoom/{roomId}/forUpdate/{bedspaceId}")]
        public async Task<IActionResult> GetBedspaces(string roomId, string bedspaceId)
        {
            _logger.LogInformation("Get Bedspaces for Update");
            return Ok(await _bedspaceRepository.GetAllForUpdate(roomId, bedspaceId));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBedspace(string id)
        {
            _logger.LogInformation("Get Bedspace by Id");
            return Ok(await _bedspaceRepository.Get(id));
        }

        [HttpPost("{roomId}")]
        public async Task<IActionResult> AddBedspace(string roomId, [FromBody] Bedspace _model)
        {
            //logger.LogInformation("Add Bedspace");
            //if (ModelState.IsValid)
            //{
            //    return Ok(await bedspaceRepository.AddBedspace(roomId, _model));
            //}
            //logger.LogWarning("Add Bedspace model is not valid");
            return BadRequest();

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBedspace(int id, [FromBody] Bedspace _model)
        {
            _logger.LogInformation("Update Bedspace");
            if (ModelState.IsValid)
            {
                await _bedspaceRepository.UpdateBedspace(id, _model);
                return Ok();
            }
            else
            {
                _logger.LogWarning("Update Bedspace model is not valid");
                return BadRequest();
            }

        }

        [HttpGet("byContract/{contractId}")]
        public async Task<IActionResult> GetByContract(string contractId)
        {
            _logger.LogInformation("Get By Contract");
            return Ok(await _bedspaceRepository.GetByContract(contractId));
        }
        [HttpPut("{bedId}/bedstatus")]
        public async Task<IActionResult> UpdateBedStatus(int bedId,[FromBody] Bedspace status)
        {
            _logger.LogInformation("Get Bedspaces by Room "+status);
            return Ok(await _bedspaceRepository.UpdateBedStatus(bedId,status.IsActive));
        }
    }
}
