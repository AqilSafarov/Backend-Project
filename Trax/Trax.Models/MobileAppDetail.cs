using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Trax.Models
{
   public class MobileAppDetail
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(500)]
        public string Title { get; set; }
        [MaxLength(500)]

        public string Desc { get; set; }
        [MaxLength(30)]
        public string Icon { get; set; }
    }
}
