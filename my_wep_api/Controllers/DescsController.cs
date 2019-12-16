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
    public class DescsController : ControllerBase
    {
        //deneme
        IDescriptionDal _descDal;

        public DescsController(IDescriptionDal descDal)
        {
            _descDal = descDal;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var titles = _descDal.GetList();

            return Ok(titles);
        }

        [HttpGet("{descId}")]
        public IActionResult Get(int descId)
        {
            try
            {
                var descs = _descDal.Get(p => p.DescId == descId);

                if (descs == null)
                {
                    return NotFound($"{descId} id'li title bulunamamıştır.");

                }

                return Ok(descs);
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]Descriptions desc)
        {
            try
            {
                _descDal.Add(desc);

                return Ok($"Yeni title eklenmiştir. ProductId: {desc.DescId}");
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody]Descriptions desc)
        {
            try
            {
                _descDal.Update(desc);

                return Ok($"{desc.DescId} 'li title güncellenmiştir.");
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }
    }
}