﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeHubPortal.Domain.Entities
{
    public class Catagory
    {
        public int CatagoryId { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }
        [StringLength(300)]
        [Required]
        public string Description { get; set; }
    }
}
