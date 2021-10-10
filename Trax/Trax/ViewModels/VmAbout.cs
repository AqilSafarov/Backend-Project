using Trax.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Trax.ViewModels
{
    public class VmAbout
    {
        public About About { get; set; }
        public List<Partner> Partner { get; set; }
        public List<Skill> Skill { get; set; }
    }
}
