using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Milky.Dto.SocialMediaDtos
{
    public class SocialMediaUpdateDto
    {
        public int SocialMediaId { get; set; }
        public string SocialMediaLink { get; set; }
        public string SocialMediaIcon { get; set; }
        public int TeamId { get; set; }
    }
}