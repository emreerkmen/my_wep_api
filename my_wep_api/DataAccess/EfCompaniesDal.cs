using my_wep_api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_wep_api.DataAccess
{
    public class EfCompaniesDal : EfEntityRepositoryBase<Companies, ResumeContext>, ICompanyDal
    {
        public EfCompaniesDal(ResumeContext context)
        : base(context)
        { }

        public List<Companies> GetProductsWithDetails()
        {
            throw new NotImplementedException();
        }
    }
}
