using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Milky.WebUI.Dtos.SliderDtos
{
    public class SliderUpdateDto
    {
        public int SliderId { get; set; }
        public string SliderImage { get; set; }
        public string SliderTitle { get; set; }
        public string SliderSubTitle { get; set; }
        public string SliderLink { get; set; }
    }
}