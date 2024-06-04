using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Milky.Dto.SubscribeDtos
{
    public class SubscribeResultDto
    {
        public int SubscribeId { get; set; }
        public string SubscribeMail { get; set; }
        public DateTime SubscribeDate { get; set; }
    }
}