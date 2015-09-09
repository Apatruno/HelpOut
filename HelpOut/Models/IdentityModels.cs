using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace HelpOut.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        public string FullName { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string Website { get; set; }

        //navigation properties
        public virtual ICollection<Event> EventsAttending { get; set; } //for volunteers
        public virtual ICollection<Event> EventsCreated { get; set; } //for organizations

        //

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public  DbSet<Event> Events { get; set; }
        public DbSet<FilePath> FilePaths { get; set; }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }


        //public System.Data.Entity.DbSet<HelpOut.Models.ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Event>()
                .HasMany(e => e.Attendees).WithMany(u => u.EventsAttending)
                .Map(t => t.MapLeftKey("EventID")
                    .MapRightKey("UserID")
                    .ToTable("Signups"));
        }


    }
}