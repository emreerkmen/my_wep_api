using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using my_wep_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_wep_api.Controllers
{
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public List<ContactModel> Get()
        {
            return new List<ContactModel>
            {
                new ContactModel{Id=1,FisrtName="Emre", LastName="Erkmen"},
            };
        }
    }
}
