using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace monovi.bookstore.model
{
    public class BaseTable
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("CreatedUser")]
        [Required]
        public int CreatedUserID { get; set; }
        public UserAccount CreatedUser { get; set; }
        [ForeignKey("ModifiedUser")]
        public int? ModifiedUserID { get; set; }
        public UserAccount ModifiedUser { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

    }
}
