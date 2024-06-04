using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Milky.Entity.Concrete;
using MilkyProject.Data.Abstract;

namespace MilkyProject.Data.Concrete.EfCore
{
    public class TestimonialDal : GenericRepository<Testimonial>, ITestimonialDal
    {
        public TestimonialDal(Context context) : base(context)
        {
            
        }
    }
}