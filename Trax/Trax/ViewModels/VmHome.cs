using Trax.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Trax.ViewModels
{
    public class VmHome
    {
        public List<Testimonial> Testimonial { get; set; }
        public Setting Setting { get; set; }
        public MobileApp MobileApp { get; set; }
        public List<MobileAppDetail> MobileAppDetail { get; set; }
        public HomeOne HomeOne { get; set; }
        public List< Slider> Slider { get; set; }
        //public List<Partner> Partner { get; set; }


    }
}
