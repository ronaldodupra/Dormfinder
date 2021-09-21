using System;
using System.Collections.Generic;
using DormFinder.Web.Services.Intefaces;
using DormFinder.Web.Data;
using DormFinder.Web.Entities;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DormFinder.Web.Services
{
    public class HomeRepository:Repository,IHomeRepository
    {
        public HomeRepository(DormFinderContext context) : base(context)
        {

        }
       
    }
}
