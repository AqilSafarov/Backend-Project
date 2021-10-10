using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Trax.Models
{
   public class Testimonial
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]

        public string Surame { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        [MaxLength(50)]

        public string CompanyName { get; set; }
        [MaxLength(50)]

        public string Country { get; set; }
        [MaxLength(2000)]

        public string Desc { get; set; }
        [MaxLength(50)]

        public string Rating { get; set; }

    }
}
