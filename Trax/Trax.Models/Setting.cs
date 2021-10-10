using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trax.Models
{
    public class Setting
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(250)]
        public string AppImage { get; set; }
        [NotMapped]
        public IFormFile ImageApp { get; set; }
        [MaxLength(250)]
        public string Logo { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        [MaxLength(2000)]
        public string About { get; set; }
        [MaxLength(50)]

        public string  Phone { get; set; }
        [MaxLength(50)]

        public string  Phone2 { get; set; }
        [MaxLength(500)]

        public string  WorkPeriodDetail { get; set; }
      
        [MaxLength(500)]

        public string  Address{ get; set; }
        [MaxLength(500)]

        public string  Address2{ get; set; }
        [MaxLength(500)]

        public string  Email{ get; set; }
        [MaxLength(500)]

        public string  Email2{ get; set; }
        [MaxLength(50)]

        public string  OpenTime{ get; set; }
        [MaxLength(20)]

        public string MondaySaturday { get; set; }
        [MaxLength(20)]

        public string Friday { get; set; }
        [MaxLength(20)]

        public string Sunday { get; set; }
        [MaxLength(20)]

        public string CalendarEvents { get; set; }

        [MaxLength(50)]

        public string  CloseTime{ get; set; }


    }
}
