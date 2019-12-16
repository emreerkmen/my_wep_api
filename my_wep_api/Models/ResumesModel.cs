using my_wep_api.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace my_wep_api.Models
{
    public class ResumesModel : IEntity
    {   [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResumeId { get; set; }

        public int TitleId { get; set; }

        public int CompantId { get; set; }

        public int DecsId { get; set; }

    }
    
}
