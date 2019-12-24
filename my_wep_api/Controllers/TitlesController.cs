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
    public class TitlesController : ControllerBase
    {
        ITitleDal _titleDal;

        public TitlesController(ITitleDal titleDal)
        {
            _titleDal = titleDal;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var titles = _titleDal.GetList();

            return Ok(titles);
        }

        [HttpGet("{titleId}")]
        public IActionResult Get(int titleId)
        {
            try
            {
                var titles = _titleDal.Get(p => p.TitleId == titleId);

                if (titles == null)
                {
                    return NotFound($"{titleId} id'li title bulunamamıştır.");

                }

                return Ok(titles);
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]Titles title)
        {
            try
            {
                _titleDal.Add(title);

                return Ok($"Yeni title eklenmiştir. ProductId: {title.TitleId}");
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody]Titles title)
        {
            try
            {
                _titleDal.Update(title);

                return Ok($"{title.TitleId} 'li title güncellenmiştir.");
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpDelete("{titleId}")]
        public IActionResult Delete(int titleId)
        {
            try
            {
                _titleDal.Delete(new Titles { TitleId = titleId });

                return Ok($"{titleId} 'li product silinmiştir.");
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }
    }
}