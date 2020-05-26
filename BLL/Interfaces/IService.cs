using System;
using System.Collections.Generic;
using DAL.Interfaces;

namespace BLL.Interfaces
{ 
    public interface IService<TObject> : IDisposable where TObject : class
    {
        IUnitOfWork Unit { get; }

        void Add(TObject obj);
        void Remove(TObject obj);
        TObject Get(int id);
        List<TObject> GetAll();
        void Update(int id, TObject obj);
    }
}
