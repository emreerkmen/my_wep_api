using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_wep_api.DataAccess;
using my_wep_api.Entities;

namespace my_wep_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        ICompanyDal _companyDal;

        public CompaniesController(ICompanyDal companyDal)
        {
            _companyDal = companyDal;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var titles = _companyDal.GetList();

            return Ok(titles);
        }

        [HttpGet("{companyId}")]
        public IActionResult Get(int companyId)
        {
            try
            {
                var companies = _companyDal.Get(p => p.CompanyId == companyId);

                if (companies == null)
                {
                    return NotFound($"{companyId} id'li title bulunamamıştır.");

                }

                return Ok(companies);
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]Companies company)
        {
            try
            {
                _companyDal.Add(company);

                return Ok($"Yeni title eklenmiştir. ProductId: {company.CompanyId}");
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody]Companies company)
        {
            try
            {
                _companyDal.Update(company);

                return Ok($"{company.CompanyId} 'li title güncellenmiştir.");
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }
    }
}