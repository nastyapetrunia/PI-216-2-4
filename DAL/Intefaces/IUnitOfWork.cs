using System;
using System.Collections.Generic;
using System.Text;
using DAL.Repositories;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ILessonRepository Lessons { get; }
        ITeacherRepository Teachers { get; }
        IGroupRepository Groups { get; }

        int Complete();
    }
}
