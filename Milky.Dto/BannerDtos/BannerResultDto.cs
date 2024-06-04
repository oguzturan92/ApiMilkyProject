using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Milky.Dto.BannerDtos
{
    public class BannerResultDto
    {
        public int BannerId { get; set; }
        public string BannerImage { get; set; }
        public string BannerTitle { get; set; }
        public string BannerSubTitle { get; set; }
        public string BannerLink { get; set; }
    }
}