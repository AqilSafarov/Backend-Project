using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Trax.Models
{
   public class Contact
    {

        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        
        [MaxLength(100)]
        public string Subtitle { get; set; }

    }
}
