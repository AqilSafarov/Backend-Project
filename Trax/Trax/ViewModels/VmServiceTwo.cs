﻿using Trax.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Trax.ViewModels
{
    public class VmServiceTwo
    {
       
        public Service Service { get; set; }
        public List < ServiceImage> ServiceImage { get; set; }
        public Setting Setting { get; set; }
        public List<Accordion> Accordion { get; set; }
        public Consultation Consultation { get; set; }
        public List<ServiceCategory> ServiceCategory { get; set; }



    }
}
