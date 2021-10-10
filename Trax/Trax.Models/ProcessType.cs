using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Trax.Models
{
    public class ProcessType
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Number { get; set; }
        [MaxLength(50)]

        public string Title { get; set; }
        [MaxLength(500)]

        public string Desc { get; set; }
    }
}
