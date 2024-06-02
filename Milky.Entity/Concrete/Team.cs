using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Milky.Entity.Concrete
{
    public class Team
    {
        public int TeamId { get; set; }
        public string TeamImage { get; set; }
        public string TeamFullname { get; set; }
        public string TeamDepartment { get; set; }
        public List<SocialMedia> SocialMedias { get; set; }
    }
}