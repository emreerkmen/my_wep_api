﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using my_wep_api.Entities;
using my_wep_api.Models;

namespace my_wep_api.DataAccess
{
    public class EfResumesDal : EfEntityRepositoryBase<Resumes, ResumeContext>, IResumeDal
    {
        public EfResumesDal(ResumeContext context)
        : base(context)
        { }
        public List<ResumeDesc> GetResumesWithDetails()
        {
            //var resultOld = from p in context.Products
            //             join c in context.Categories
            //             on p.CategoryId equals c.CategoryId
            //             select new ProductModel
            //             {
            //                 ProductId = p.ProductId,
            //                 ProductName = p.ProductName,
            //                 CategoryName = c.CategoryName,
            //                 CategoryDescription = c.Description
            //             };

            var result = from r in _resumeContext.Resumes
                            join t in _resumeContext.Titles on r.TitleId equals t.TitleId
                            join c in _resumeContext.Companies on r.CompantId equals c.CompanyId
                            join d in _resumeContext.Descriptions on r.DecsId equals d.DescId
                            select new ResumeDesc
                            {
                                ResumeId = r.ResumeId,
                                Title = t.Title,
                                StartDate = t.StartDate,
                                EndDate = t.EndDate,
                                CompanyName = c.CompanyName,
                                Description = d.Description
                            };

            return result.ToList();
            
        }
    }
}
