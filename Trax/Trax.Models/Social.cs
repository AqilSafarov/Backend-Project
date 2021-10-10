using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trax.Models
{
    public class Social
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(30)]
        public string Icon { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
     
        public List<SocialToTeamMember> SocialToTeamMembers { get; set; }
    }
}
