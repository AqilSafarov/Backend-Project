using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Trax.Models
{
    public class About
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(100)]

        public string Title2 { get; set; }
        [MaxLength(2000)]

        public string Desc { get; set; }
        [MaxLength(2000)]

        public string Desc2 { get; set; }
        [MaxLength(250)]

        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
