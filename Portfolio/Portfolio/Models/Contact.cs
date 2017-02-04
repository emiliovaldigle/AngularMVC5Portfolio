using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Portafolio.Models
{
    public class Contact
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid idContact { get; set; }
        public string Mail { get; set; }
        public string Enterprise { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
       
    }
}