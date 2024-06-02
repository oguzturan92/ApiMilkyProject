using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Milky.WebUI.Dtos.BannerDtos
{
    public class BannerCreateDto
    {
        public string BannerImage { get; set; }
        public string BannerTitle { get; set; }
        public string BannerSubTitle { get; set; }
        public string BannerLink { get; set; }
    }
}