using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using my_wep_api.Entities;
using my_wep_api.Models;

namespace my_wep_api.DataAccess
{
    public interface IResumeDal : IEntityRepository<Resumes>
    {
        //Buraya custom sorgular yazılır.

        List<ResumeDesc> GetResumesWithDetails();
    }
}
