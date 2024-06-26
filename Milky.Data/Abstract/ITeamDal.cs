using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Milky.Entity.Concrete;

namespace MilkyProject.Data.Abstract
{
    public interface ITeamDal : IGenericDal<Team>
    {
        List<Team> GetTeamsListAndSocials();
    }
}