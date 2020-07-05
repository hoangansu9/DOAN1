using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace doan_1.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        public string Image { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageUpLoad { get; set; }
        public override string PhoneNumber { get; set; }
        public string Sex { get; set; }
        public DateTime? UserDateOfBirth { get; set; }
        public string Address { get; set; }
      // public string Phone { get; set; }

        [ForeignKey("UserId")]
        public ICollection<Order> Order { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public DbSet<Author> Author { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<Provider> Provider { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityUser>()
                                               .Ignore(c => c.AccessFailedCount)

                                               .Ignore(c => c.LockoutEnabled)
                                                .Ignore(c => c.LockoutEndDateUtc)
                                               //.Ignore(c => c.PhoneNumber)
                                               .Ignore(c => c.PhoneNumberConfirmed)
                                               .Ignore(c => c.EmailConfirmed)
                                               .Ignore(c => c.TwoFactorEnabled) 
                                               ;
            modelBuilder.Entity<IdentityUser>().ToTable("AspNetUsers");

        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}