using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace monovi.bookstore.model
{
    public class Product : BaseTable
    {
        [Display(Name = "Product Name")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Display(Name = "Author")]
        [Required]
        [MaxLength(200)]
        public string Author { get; set; }
        [Display(Name = "ISBN")]
        [Required]
        [MaxLength(25)]
        public string ISBN { get; set; }
        [Display(Name = "Description")]
        [MaxLength(500)]
        public string Description { get; set; }


    }
}
