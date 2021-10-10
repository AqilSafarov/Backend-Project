using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Trax.Models
{
   public class SocialToTeamMember
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(250)]
        public string Link { get; set; }

        [ForeignKey("Social")]
        public int SocialId { get; set; }
        public Social Social { get; set; }

        [ForeignKey("TeamMember")]
        public int TeamMemberId { get; set; }
        public TeamMember TeamMember { get; set; }
    }
}
