using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Trax.Models
{
   public class Page
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public List<PageDetail> PageDetails { get; set; }
        public List<Banner> Banners { get; set; }

    }
}
