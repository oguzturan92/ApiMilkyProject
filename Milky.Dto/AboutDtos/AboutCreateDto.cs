using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Milky.Dto.AboutDtos
{
    public class AboutCreateDto
    {
        public string AboutTitle { get; set; }
        public string AboutDescription { get; set; }
        public string AboutImage1 { get; set; }
        public string AboutImage2 { get; set; }
        public string AboutImage3 { get; set; }
    }
}