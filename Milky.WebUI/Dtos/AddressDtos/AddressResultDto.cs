using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Milky.WebUI.Dtos.AddressDtos
{
    public class AddressResultDto
    {
        public int AddressId { get; set; }
        public string AddressContent { get; set; }
        public string AddressPhone { get; set; }
        public string AddressMail { get; set; }
        public string AddressMapUrl { get; set; }
    }
}