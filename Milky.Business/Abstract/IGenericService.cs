using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilkyProject.Business.Abstract
{
    public interface IGenericService<T> where T : class
    {
        void Insert(T entity);
        void Delete(int id);
        void Update(T entity);
        List<T> GetListAll();
        T GetById(int id);
    }
}