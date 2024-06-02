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
    public class TeamManager : ITeamService
    {
        private readonly ITeamDal _teamDal;
        public TeamManager(ITeamDal teamDal)
        {
            _teamDal = teamDal;
        }
        public void Delete(int id)
        {
            _teamDal.Delete(id);
        }

        public Team GetById(int id)
        {
            return _teamDal.GetById(id);
        }

        public List<Team> GetListAll()
        {
            return _teamDal.GetListAll();
        }

        public List<Team> GetTeamsListAndSocials()
        {
            return _teamDal.GetTeamsListAndSocials();
        }

        public void Insert(Team entity)
        {
            _teamDal.Insert(entity);
        }

        public void Update(Team entity)
        {
            _teamDal.Update(entity);
        }
    }
}