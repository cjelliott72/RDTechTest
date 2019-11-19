using System;
using System.ComponentModel.DataAnnotations;

namespace UserManager.Web.Models
{
    /// <summary>
    /// User entity
    /// </summary>
    public class User
    {
        /// <summary>
        /// Unique Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// First Name
        /// </summary>
        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }

        /// <summary>
        /// Last Name
        /// </summary>
        [Required]
        [StringLength(20)]
        public string LastName { get; set; }

        /// <summary>
        /// Email Address
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        /// <summary>
        /// Date Of Birth
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Customer Code
        /// </summary>
        [Required]
        [StringLength(50)]
        public string CustCode { get; set; }
    }
}
