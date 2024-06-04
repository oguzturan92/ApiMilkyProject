using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Milky.Entity.Concrete;
using MilkyProject.Data.Abstract;

namespace MilkyProject.Data.Concrete.EfCore
{
    public class SocialMediaDal : GenericRepository<SocialMedia>, ISocialMediaDal
    {
        public SocialMediaDal(Context context) : base(context)
        {
            
        }

        public List<SocialMedia> SocialMediaListByTeamId(int id)
        {
            using (var context = new Context())
            {
                return context.SocialMedias
                                        .Where(i => i.TeamId == id)
                                        .ToList();
            }
        }
    }
}