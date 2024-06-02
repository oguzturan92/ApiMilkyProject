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
    public class SiteSocialMediaManager : ISiteSocialMediaService
    {
        private readonly ISiteSocialMediaDal _siteSocialMediaDal;
        public SiteSocialMediaManager(ISiteSocialMediaDal siteSocialMediaDal)
        {
            _siteSocialMediaDal = siteSocialMediaDal;
        }
        public void Delete(int id)
        {
            _siteSocialMediaDal.Delete(id);
        }

        public SiteSocialMedia GetById(int id)
        {
            return _siteSocialMediaDal.GetById(id);
        }

        public List<SiteSocialMedia> GetListAll()
        {
            return _siteSocialMediaDal.GetListAll();
        }

        public void Insert(SiteSocialMedia entity)
        {
            _siteSocialMediaDal.Insert(entity);
        }

        public void Update(SiteSocialMedia entity)
        {
            _siteSocialMediaDal.Update(entity);
        }
    }
}