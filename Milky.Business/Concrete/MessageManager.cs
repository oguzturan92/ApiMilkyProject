using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Milky.Entity.Concrete;
using MilkyProject.Business.Abstract;
using MilkyProject.Data.Abstract;
using MilkyProject.Entity.Concrete;

namespace MilkyProject.Business.Concrete
{
    public class MessageManager : IMessageService
    {
        private readonly IMessageDal _messageDal;
        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }
        public void Delete(int id)
        {
            _messageDal.Delete(id);
        }

        public Message GetById(int id)
        {
            return _messageDal.GetById(id);
        }

        public List<Message> GetListAll()
        {
            return _messageDal.GetListAll();
        }

        public void Insert(Message entity)
        {
            _messageDal.Insert(entity);
        }

        public void Update(Message entity)
        {
            _messageDal.Update(entity);
        }
    }
}