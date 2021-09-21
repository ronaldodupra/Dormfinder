using System;
using System.Collections.Generic;
using DormFinder.Web.Services.Intefaces;
using System.Threading.Tasks;
using DormFinder.Web.Models;
using DormFinder.Web.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DormFinder.Web.Controllers
{
    [Route("api/home")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        public readonly IHomeRepository _homeRepository;
        public HomeController(IHomeRepository homeRepository)
        {
            _homeRepository = homeRepository;
        }
       
    }
}
