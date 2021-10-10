using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trax.Models;

namespace Trax.ViewModels
{
    public class VmTeamMem
    {
        public List<TeamMember> TeamMember { get; set; }
        public Expert Expert { get; set; }
        public List<Social> Social { get; set; }
        public List<SocialToTeamMember> SocialToTeamMember { get; set; }
        public Position Position { get; set; }



    }
}
