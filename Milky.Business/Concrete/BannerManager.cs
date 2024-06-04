using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Milky.Entity.Concrete;
using MilkyProject.Business.Abstract;
using MilkyProject.Data.Abstract;

namespace MilkyProject.Business.Concrete
{
    public class BannerManager : IBannerService
    {
        private readonly IBannerDal _bannerDal;
        public BannerManager(IBannerDal bannerDal)
        {
            _bannerDal = bannerDal;
        }
        public void Delete(int id)
        {
            _bannerDal.Delete(id);
        }

        public Banner GetById(int id)
        {
            return _bannerDal.GetById(id);
        }

        public List<Banner> GetListAll()
        {
            return _bannerDal.GetListAll();
        }

        public void Insert(Banner entity)
        {
            _bannerDal.Insert(entity);
        }

        public void Update(Banner entity)
        {
            _bannerDal.Update(entity);
        }
    }
}