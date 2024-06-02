using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Milky.WebUI.Dtos.ServiceDtos
{
    public class ServiceCreateDto
    {
        public string ServiceFullname { get; set; }
        public string ServiceTitle { get; set; }
        public string ServiceDescription { get; set; }
        public string ServiceImage { get; set; }
    }
}