using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;

namespace DAL.Interfaces
{
    public interface ITeacherRepository : IRepository<Teacher>
    {
        IEnumerable<Lesson> GetLessons(int id);
    }
}
