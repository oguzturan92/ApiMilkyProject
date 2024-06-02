using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Milky.WebUI.Dtos.SliderDtos
{
    public class SliderCreateDto
    {
        public string SliderImage { get; set; }
        public string SliderTitle { get; set; }
        public string SliderSubTitle { get; set; }
        public string SliderLink { get; set; }
    }
}