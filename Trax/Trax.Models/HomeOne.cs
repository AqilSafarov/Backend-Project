using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Trax.Models
{
    public  class HomeOne
    {
        [Key]
        public int Id { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        [MaxLength(200)]
        public string Title { get; set; }
        [MaxLength(2000)]

        public string Desc { get; set; }
    }
}
