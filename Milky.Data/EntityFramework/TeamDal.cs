using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Milky.Entity.Concrete;
using MilkyProject.Data.Abstract;
using MilkyProject.Entity.Concrete;

namespace MilkyProject.Data.Concrete.EfCore
{
    public class TeamDal : GenericRepository<Team>, ITeamDal
    {
        public TeamDal(Context context) : base(context)
        {
            
        }

        public List<Team> GetTeamsListAndSocials()
        {
            using (var context = new Context())
            {
                return context.Teams
                            .Select(i => new Team()
                            {
                                TeamId = i.TeamId,
                                TeamFullname = i.TeamFullname,
                                TeamDepartment = i.TeamDepartment,
                                TeamImage = i.TeamImage,
                                SocialMedias = i.SocialMedias
                            }).ToList();
            }
        }
    }
}