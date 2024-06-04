using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Milky.Entity.Concrete;
using MilkyProject.Data.Abstract;

namespace MilkyProject.Data.Concrete.EfCore
{
    public class AddressDal : GenericRepository<Address>, IAddressDal
    {
        public AddressDal(Context context) : base(context)
        {
            
        }
    }
}