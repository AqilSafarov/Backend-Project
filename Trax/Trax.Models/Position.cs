using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Trax.Models;

namespace Trax.Models
{
    public class Position
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        public List<TeamMember> TeamMembers { get; set; }

    }
}
