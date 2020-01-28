using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace monovi.bookstore.model
{
    public class UserAccount 
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "User Name")]
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }
        [Display(Name = "Name Surname")]
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }
        [Display(Name = "Email")]
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

    }
}
