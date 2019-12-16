using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace my_wep_api.Entities
{
    public class Categories : IEntity
    {
        private int categoryId;
        private string categoryName;
        private string description;
        [Key]
        public int CategoryId { get => categoryId; set => categoryId = value; }
        public string CategoryName { get => categoryName; set => categoryName = value; }
        public string Description { get => description; set => description = value; }
    }
}
