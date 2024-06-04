using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Milky.Entity.Concrete;
using MilkyProject.Data.Abstract;

namespace MilkyProject.Data.Concrete.EfCore
{
    public class BannerDal : GenericRepository<Banner>, IBannerDal
    {
        public BannerDal(Context context) : base(context)
        {
            
        }
    }
}