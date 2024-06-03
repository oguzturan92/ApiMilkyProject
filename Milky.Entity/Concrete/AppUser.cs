using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Milky.Entity.Concrete
{
    public class AppUser : IdentityUser<int>
    {
        public string UserAdi { get; set; }
        public string UserSoyadi { get; set; }
        public DateTime UserRegisterDate { get; set; }
    }
}