using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MilkyProject.Business.Abstract;
using MilkyProject.Data.Abstract;
using MilkyProject.Entity.Concrete;

namespace MilkyProject.Business.Concrete
{
    public class SliderManager : ISliderService
    {
        private readonly ISliderDal _sliderDal;
        public SliderManager(ISliderDal sliderDal)
        {
            _sliderDal = sliderDal;
        }
        public void Delete(int id)
        {
            _sliderDal.Delete(id);
        }

        public Slider GetById(int id)
        {
            return _sliderDal.GetById(id);
        }

        public List<Slider> GetListAll()
        {
            return _sliderDal.GetListAll();
        }

        public void Insert(Slider entity)
        {
            _sliderDal.Insert(entity);
        }

        public void Update(Slider entity)
        {
            _sliderDal.Update(entity);
        }
    }
}