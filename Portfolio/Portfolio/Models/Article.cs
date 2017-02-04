using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Portafolio.Models
{
    public class Article
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid idArticle { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }
    }
}