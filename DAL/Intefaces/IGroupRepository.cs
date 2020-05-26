using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IGroupRepository : IRepository<Group>
    {
        IEnumerable<Lesson> GetLessons(int id);
    }
}
