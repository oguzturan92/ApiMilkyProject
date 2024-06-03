using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Milky.Dto.AppUserDtos
{
    public class UserRegisterDto
    {
        public string UserAdi { get; set; }
        public string UserSoyadi { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
    }
}