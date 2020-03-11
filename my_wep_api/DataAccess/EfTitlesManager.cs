using Microsoft.EntityFrameworkCore;
using my_wep_api.Entities;
using my_wep_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace my_wep_api.DataAccess
{
    public class EfTitlesManager : EfEntityRepositoryBase<Titles, ResumeContext>, ITitleDal
    {
        public EfTitlesManager(ResumeContext context)
        : base(context)
        { }
        List<Titles> ITitleDal.GetTitlesWithDetails()
        {
            var result = from t in _resumeContext.Titles
                            select new Titles
                            {
                                Title = t.Title
                            };

            return result.ToList();
        }
    }
}
