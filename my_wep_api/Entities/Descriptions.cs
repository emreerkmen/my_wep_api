using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace my_wep_api.Entities
{
    public class Descriptions : IEntity
    {
        [Key]
        public int DescId { get; set; }
        public string Description { get; set; }
    }
}
