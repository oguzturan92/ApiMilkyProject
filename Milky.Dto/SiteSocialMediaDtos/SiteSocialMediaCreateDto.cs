using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Milky.Dto.SiteSocialMediaDtos
{
    public class SiteSocialMediaCreateDto
    {
        public int SiteSocialMediaId { get; set; }
        public string SiteSocialMediaLink { get; set; }
        public string SiteSocialMediaIcon { get; set; }
    }
}