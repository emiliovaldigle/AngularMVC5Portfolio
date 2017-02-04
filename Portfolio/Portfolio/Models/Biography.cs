using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Portafolio.Models
{
    public class Biography
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid idBiography { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public bool Active { get; set; }
    }
}