using Trax.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Trax.ViewModels
{
    public class VmFooter
    {
        public List< Social> Social { get; set; }
        public List<SocialToTeamMember> SocialToTeamMember { get; set; }
        public Setting Setting { get; set; }
        public Contact Contact { get; set; }
        public PageDetail PageDetail { get; set; }
        public Message Message { get; set; }
    }
}
