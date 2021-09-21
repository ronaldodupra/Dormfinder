using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DormFinder.Web.Entities;

namespace DormFinder.Web.Services.Intefaces
{
    public interface IInclusionRepository
    {
        Task<IEnumerable<Inclusion>> GetInclusions();
        
    }
}
