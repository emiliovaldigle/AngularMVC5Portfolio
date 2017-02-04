using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Portafolio.Models
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid idCategory { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Competence> Competences { get; set; }
    }
    public class Competence
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid idCompetence { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public Guid idCategory { get; set; }
        [ForeignKey("idCategory")]
        public virtual Category Category { get; set; }
    }
}