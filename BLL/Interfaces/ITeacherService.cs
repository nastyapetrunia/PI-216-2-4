using System.Collections.Generic;
using BLL.Objects;

namespace BLL.Interfaces
{
    public interface ITeacherService : IService<Teacher>
    {
        IEnumerable<Lesson> GetLessons(int id);
    }
}
