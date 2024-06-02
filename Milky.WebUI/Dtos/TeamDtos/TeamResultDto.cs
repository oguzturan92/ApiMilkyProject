using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Milky.WebUI.Dtos.TeamDtos
{
    public class TeamResultDto
    {
        public int TeamId { get; set; }
        public string TeamImage { get; set; }
        public string TeamFullname { get; set; }
        public string TeamDepartment { get; set; }
    }
}