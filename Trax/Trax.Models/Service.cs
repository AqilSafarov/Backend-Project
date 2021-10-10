using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Trax.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(500)]

        public string Title { get; set; }
        [MaxLength(250)]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }

        public string Desc { get; set; }
        [ForeignKey("ServiceCategory")]

        public int ServiceCategoryId { get; set; }
        public ServiceCategory ServiceCategory { get; set; }
        public List<ServiceImage> ServiceImages { get; set; }
        public List<Accordion> Accordions { get; set; }
    }
}
