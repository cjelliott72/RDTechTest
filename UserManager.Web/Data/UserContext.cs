using Microsoft.EntityFrameworkCore;
using System;
using UserManager.Web.Models;

namespace UserManager.Web.Data
{
    /// <summary>
    /// The EFCore database context class 
    /// </summary>
    public class UserContext : DbContext
    {
        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="options">DbContextOptions</param>
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        /// <summary>
        /// User DbSet
        /// </summary>
        public DbSet<User> User { get; set; }

        /// <summary>
        /// Overide virtual OnModelBuilder method to seed the database
        /// </summary>
        /// <param name="builder">ModelBuilder</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().HasData(
                new User { Id = 1, FirstName = "Roger", LastName = "Waters", Email = "rwaters@floydmail.com", DateOfBirth = DateTime.Parse("1950/03/15") },
                new User { Id = 2, FirstName = "David", LastName = "Gilmour", Email = "dgilmour@floydmail.com", DateOfBirth = DateTime.Parse("1955/08/12") },
                new User { Id = 3, FirstName = "Nick", LastName = "Mason", Email = "nmason@floydmail.com", DateOfBirth = DateTime.Parse("1952/11/01") },
                new User { Id = 4, FirstName = "Richard", LastName = "Wright", Email = "rwright@floydmail.com", DateOfBirth = DateTime.Parse("1957/08/10") },
                new User { Id = 5, FirstName = "Syd", LastName = "Barrett", Email = "sbarrett@floydmail.com", DateOfBirth = DateTime.Parse("1954/02/22") }
                );
        }
    }
}
