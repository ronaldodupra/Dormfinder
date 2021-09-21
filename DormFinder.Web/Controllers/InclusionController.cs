using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DormFinder.Web.Entities;
using DormFinder.Web.Services.Intefaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace DormFinder.Web.Controllers
{
    [Route("api/inclusion")]
    [Authorize]
    public class InclusionController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IInclusionRepository _inclusionRepository;

        public InclusionController(IMapper mapper,IInclusionRepository inclusionRepository) 
        {
            _inclusionRepository = inclusionRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inclusion>>> GetInclusions()
        {
            var getInclusion = await _inclusionRepository.GetInclusions();

            return getInclusion.ToList();
        }
        
    }
}
