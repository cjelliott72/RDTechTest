using Microsoft.EntityFrameworkCore;
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
        /// Class constructor
        /// </summary>
        /// <param name="options">DbContextOptions</param>
        public DbSet<UserManager.Web.Models.User> User { get; set; }


        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);

        //    builder.Entity<People>().HasData(
        //        new People { Id = 1, Name = "Bob Smith", DateOfBirth = DateTime.Parse("1980/12/01") },
        //        new People { Id = 2, Name = "Jane Auburn", DateOfBirth = DateTime.Parse("1988/03/22") },
        //        new People { Id = 3, Name = "William Burrows", DateOfBirth = DateTime.Parse("1979/04/05") }
        //        );
        //}
    }
}
