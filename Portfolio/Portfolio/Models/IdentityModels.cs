using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Portafolio.Models;

namespace Portfolio.Models
{
    // Puede agregar datos del perfil del usuario agregando más propiedades a la clase ApplicationUser. Para más información, visite http://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("PPConnection", throwIfV1Schema: false)
        {
        }
        public virtual DbSet<Article> Article { get; set; }
        public virtual DbSet<Biography> Biography { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<Image> Image { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Competence> Competence { get; set; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}