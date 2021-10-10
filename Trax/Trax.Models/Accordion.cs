using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Trax.Models
{
   public class Accordion
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(500)]
        public string Desc { get; set; }
        [ForeignKey("Service")]
        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}
