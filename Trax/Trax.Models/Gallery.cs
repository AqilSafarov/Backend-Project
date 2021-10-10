using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Trax.Models
{
    public class Gallery
    {
        public int Id { get; set; }
        [MaxLength(250)]

        public string Image { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }

        [ForeignKey("GalleryCategory")]
        public int GalleryCategoryId { get; set; }
        public GalleryCategory GalleryCategory { get; set; }
    }
}
