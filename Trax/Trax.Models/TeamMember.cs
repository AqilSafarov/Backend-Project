using Trax.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Trax.Models
{
   public class TeamMember
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]

        public string Surame { get; set; }
        public string Image{ get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }

        [ForeignKey("Position")]
        public int PositionId { get; set; }
        public Position Position { get; set; }
        public List<SocialToTeamMember> SocialToTeamMembers { get; set; }
    }
}
