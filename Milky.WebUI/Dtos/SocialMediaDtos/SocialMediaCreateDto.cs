using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Milky.WebUI.Dtos.SocialMediaDtos
{
    public class SocialMediaCreateDto
    {
        public string SocialMediaLink { get; set; }
        public string SocialMediaIcon { get; set; }
        public int TeamId { get; set; }
    }
}