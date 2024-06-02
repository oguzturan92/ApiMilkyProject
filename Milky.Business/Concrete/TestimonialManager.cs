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
    public class TestimonialManager : ITestimonialService
    {
        private readonly ITestimonialDal _testimonialDal;
        public TestimonialManager(ITestimonialDal testimonialDal)
        {
            _testimonialDal = testimonialDal;
        }
        public void Delete(int id)
        {
            _testimonialDal.Delete(id);
        }

        public Testimonial GetById(int id)
        {
            return _testimonialDal.GetById(id);
        }

        public List<Testimonial> GetListAll()
        {
            return _testimonialDal.GetListAll();
        }

        public void Insert(Testimonial entity)
        {
            _testimonialDal.Insert(entity);
        }

        public void Update(Testimonial entity)
        {
            _testimonialDal.Update(entity);
        }
    }
}