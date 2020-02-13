using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Airport.Models
{
    // Vous pouvez ajouter des données de profil pour l'utilisateur en ajoutant d'autres propriétés à votre classe ApplicationUser. Pour en savoir plus, consultez https://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Notez qu'authenticationType doit correspondre à l'élément défini dans CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Ajouter les revendications personnalisées de l’utilisateur ici
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Personne>()
                        .HasMany<Reservation>(s => s.Reservations)
                        .WithMany(c => c.Personnes)
                        .Map(cs =>
                        {
                            cs.MapLeftKey("PersonneId");
                            cs.MapRightKey("ReservationId");
                            cs.ToTable("PersonneReservation");
                        });

        }

        public System.Data.Entity.DbSet<Airport.Models.Personne> Personnes { get; set; }

        public System.Data.Entity.DbSet<Airport.Models.RolePersonne> RolePersonnes { get; set; }

        public System.Data.Entity.DbSet<Airport.Models.Reservation> Reservations { get; set; }
    }
}