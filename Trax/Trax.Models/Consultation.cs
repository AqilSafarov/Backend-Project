using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Trax.Models
{
    public class Consultation
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Fullname { get; set; }
        [MaxLength(50), Required]
        public string Email { get; set; }
        [MaxLength(2000), Required]
        public string Text { get; set; }
        [MaxLength(50), Required]

        public string CompanyName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
