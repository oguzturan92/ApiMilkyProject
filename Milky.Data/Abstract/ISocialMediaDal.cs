using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Milky.Entity.Concrete;
using MilkyProject.Entity.Concrete;

namespace MilkyProject.Data.Abstract
{
    public interface ISocialMediaDal : IGenericDal<SocialMedia>
    {
        List<SocialMedia> SocialMediaListByTeamId(int id);
    }
}