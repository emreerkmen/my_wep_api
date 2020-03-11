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
    public class ResumesController : ControllerBase
    {
        IResumeDal _resumeDal;

        public ResumesController(IResumeDal resumeDal)
        {
            _resumeDal = resumeDal;
        }

        // GET: api/Resumes
        [HttpGet]
        public IActionResult Get()
        {
            var resumes = _resumeDal.GetList();

            return Ok(resumes);
        }

        [HttpGet("GetDetail")]
        public IActionResult GetDetail()
        {
            var resumes = _resumeDal.GetResumesWithDetails();

            return Ok(resumes);
        }

        // GET: api/Resumes/5
        [HttpGet("{resumeId}")]
        public IActionResult Get(int resumeId)
        {
            try
            {
                var resume = _resumeDal.Get(p => p.ResumeId == resumeId);

                if (resume == null)
                {
                    return NotFound($"{resumeId} id'li resume bulunamamıştır.");

                }

                return Ok(resume);
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }
        }

        // POST: api/Resumes
        [HttpPost]
        public IActionResult Post([FromBody] Resumes resume)
        {
            try
            {
                _resumeDal.Add(resume);

                return Ok($"Yeni resume eklenmiştir. ProductId: {resume.ResumeId}");
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        // PUT: api/Resumes
        [HttpPut]
        public IActionResult Put([FromBody] Resumes resume)
        {
            try
            {
                _resumeDal.Update(resume);

                return Ok($"{resume.ResumeId} 'li resume güncellenmiştir.");
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{resumeId}")]
        public IActionResult Delete(int resumeId)
        {
            try
            {
                _resumeDal.Delete(new Resumes { ResumeId = resumeId });

                return Ok($"{resumeId} 'li product silinmiştir.");
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

    }
}
