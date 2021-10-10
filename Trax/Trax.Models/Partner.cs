using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trax.Models
{
    public class Partner
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(250)]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        [MaxLength(500)]
        public string Link { get; set; }
        [MaxLength(50)]

        public string Name { get; set; }
    }
}
