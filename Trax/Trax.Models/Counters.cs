using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Trax.Models
{
    public class Counters
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(250)]
        public string ImageBg { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }

        public int StartYear { get; set; }

        public int StudentCount { get; set; }
        [MaxLength(2000)]

        public string Desc { get; set; }
        [MaxLength(200)]

        public string Subtitle { get; set; }
        [MaxLength(200)]

        public string Subtitle2 { get; set; }

    }
}
