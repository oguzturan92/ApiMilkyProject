using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Milky.Entity.Concrete
{
    public class SocialMedia
    {
        public int SocialMediaId { get; set; }
        public string SocialMediaLink { get; set; }
        public string SocialMediaIcon { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}