using System;

namespace DormFinder.Web.Entities
{
    public interface IBaseEntity
    {
        public DateTime CreatedAt { get; }

        public int CreatedById { get; }

        public DateTime UpdatedAt { get; }

        public int UpdatedById { get; }
    }
}
