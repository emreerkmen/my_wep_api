using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace my_wep_api.Entities
{
    public class Resumes
    {
        [Key]
        public int ResumeId { get; set; }

        public int TitleId { get; set; }

        public int CompantId { get; set; }

        public int DecsId { get; set; }
    }
}
