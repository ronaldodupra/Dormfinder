using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DormFinder.Web.Data;
using DormFinder.Web.Entities;
using DormFinder.Web.Services.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace DormFinder.Web.Services
{
    public class InclusionRepository: Repository,IInclusionRepository
    {
        public InclusionRepository(DormFinderContext context):base(context)
        {

        }
        public async Task<IEnumerable<Inclusion>> GetInclusions()
        {
            return await _context.Inclusions.ToListAsync();
        }
        
    }
}
