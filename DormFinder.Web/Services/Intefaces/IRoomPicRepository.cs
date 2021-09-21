using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DormFinder.Web.Services.Intefaces
{
    public interface IRoomPicRepository
    {
        Task Remove(int Id);
        Task SetUpThumbNail(int roomId, int id);
    }
}
