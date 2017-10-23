using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using AdApp.DAL.Entities;
using AdApp.DAL.Entities.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AdApp.DAL.EF
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext(string connectionString)
            : base(connectionString)
        {
        }

        public DbSet<ClientProfile> ClientProfiles { get; set; }

        public DbSet<Advert> Adverts { get; set; }

        static ApplicationContext()
        {
            Database.SetInitializer(new AppDbInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientProfile>().HasRequired(x => x.ApplicationUser).WithRequiredDependent().WillCascadeOnDelete(true);
            modelBuilder.Entity<Advert>().HasOptional(x => x.ApplicationUser).WithMany().WillCascadeOnDelete(true);
            
            modelBuilder.Entity<ApplicationUser>().HasRequired(x => x.Roles).WithMany().WillCascadeOnDelete(true);


            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}