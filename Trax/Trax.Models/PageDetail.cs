using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Trax.Models
{
  public  class PageDetail
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(2000)]

        public string Desc { get; set; }
        [ForeignKey("Page")]
        public int PageId { get; set; }
        public Page Page { get; set; }

    }
}
