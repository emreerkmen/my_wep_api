using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace my_wep_api.Entities
{
    public class Companies : IEntity
    {
        [Key]
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
    }
}
