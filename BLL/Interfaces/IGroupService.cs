using System.Collections.Generic;
using BLL.Objects;

namespace BLL.Interfaces
{
    public interface IGroupService : IService<Group>
    {
        IEnumerable<Lesson> GetLessons(int id);
    }
}
