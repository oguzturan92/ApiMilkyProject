using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Milky.Entity.Concrete;
using MilkyProject.Data.Abstract;
using MilkyProject.Entity.Concrete;

namespace MilkyProject.Data.Concrete.EfCore
{
    public class SiteSocialMediaDal : GenericRepository<SiteSocialMedia>, ISiteSocialMediaDal
    {
        public SiteSocialMediaDal(Context context) : base(context)
        {
            
        }
    }
}