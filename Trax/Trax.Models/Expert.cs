using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Trax.Models
{
    public class Expert
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(500)]
        public string Subtitle { get; set; }
        [MaxLength(200)]

        public string Title { get; set; }

        [MaxLength(2000)]

        public string Desc { get; set; }

    }
}
