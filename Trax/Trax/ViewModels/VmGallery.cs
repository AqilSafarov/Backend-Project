using Trax.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Trax.ViewModels
{
    public class VmGallery
    {
        public About About { get; set; }
        public List<Partner> Partner { get; set; }
        public List<Gallery> Gallery { get; set; }
        public List<GalleryCategory> GalleryCategory { get; set; }
    }
}
