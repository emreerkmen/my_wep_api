using my_wep_api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_wep_api.DataAccess
{
    public class EfDescriptionsDal : EfEntityRepositoryBase<Descriptions, ResumeContext>, IDescriptionDal
    {
        public EfDescriptionsDal(ResumeContext context)
        : base(context)
        { }
        public List<Descriptions> GetProductsWithDetails()
        {
            throw new NotImplementedException();
        }
    }
}
