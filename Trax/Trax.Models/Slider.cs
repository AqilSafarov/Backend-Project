using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Trax.Models
{
    public class Slider
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(250)]
        public string ImageBg { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        [MaxLength(500)]
        public string Title { get; set; }
        [MaxLength(500)]
        public string Title2 { get; set; }
        [MaxLength(500)]
        public string Title3 { get; set; }

        [MaxLength(100)]
        public string Subtitle { get; set; }
    }
}
