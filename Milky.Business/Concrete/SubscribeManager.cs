using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Milky.Entity.Concrete;
using MilkyProject.Business.Abstract;
using MilkyProject.Data.Abstract;

namespace MilkyProject.Business.Concrete
{
    public class SubscribeManager : ISubscribeService
    {
        private readonly ISubscribeDal _subscribeDal;
        public SubscribeManager(ISubscribeDal subscribeDal)
        {
            _subscribeDal = subscribeDal;
        }
        public void Delete(int id)
        {
            _subscribeDal.Delete(id);
        }

        public Subscribe GetById(int id)
        {
            return _subscribeDal.GetById(id);
        }

        public List<Subscribe> GetListAll()
        {
            return _subscribeDal.GetListAll();
        }

        public void Insert(Subscribe entity)
        {
            _subscribeDal.Insert(entity);
        }

        public void Update(Subscribe entity)
        {
            _subscribeDal.Update(entity);
        }
    }
}