using my_wep_api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_wep_api.DataAccess
{
    public interface ICompanyDal : IEntityRepository<Companies>
    {
        List<Companies> GetProductsWithDetails();
    }
}
