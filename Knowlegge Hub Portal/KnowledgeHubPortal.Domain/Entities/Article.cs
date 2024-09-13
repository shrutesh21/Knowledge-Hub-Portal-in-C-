using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeHubPortal.Domain.Entities
{
    public class Article
    {
        public int ArticleId { get; set; }
        [Required]
        [MinLength(6)]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
        [Required]
        [Url]
        public string ArticleUrl { get; set; }
        public int CatagoryId { get; set; }
        public Catagory? Catagory { get; set; }
        public bool IsApproved { get; set; }
        public string? SubmittedBy { get; set; }
        public DateTime DateSubmitted { get; set; }
    }
}
