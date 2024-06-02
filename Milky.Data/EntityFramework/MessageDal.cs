using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Milky.Entity.Concrete;
using MilkyProject.Data.Abstract;
using MilkyProject.Entity.Concrete;

namespace MilkyProject.Data.Concrete.EfCore
{
    public class MessageDal : GenericRepository<Message>, IMessageDal
    {
        public MessageDal(Context context) : base(context)
        {
            
        }
    }
}