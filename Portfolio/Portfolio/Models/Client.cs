using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Portafolio.Models
{
    public class Client
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid idClient { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
    public class Project
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid idProject { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid idClient { get; set; }
        public virtual Client Client { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }
    public class Image
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid idImage { get; set; }
        public string Path { get; set; }
        public Guid idProject { get; set; }
        public virtual Project Project { get; set; }
    }
}