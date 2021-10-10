using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trax.Models;
using Trax.Services;
using Trax.Services.Repository.IRepository;
using Trax.ViewModels;

namespace Trax.Controllers
{
    public class GalleryController : Controller
    {
        private readonly ISubscribe _subscribe;
        private readonly IGallery _gallery;
        private readonly AppDbContext _context;
        private readonly IGalleryCategory _galleryCategory;

        public GalleryController(ISubscribe subscribe,IGallery gallery,AppDbContext context, IGalleryCategory galleryCategory)
        {
            _subscribe = subscribe;
            _gallery = gallery;
            _context = context;
            _galleryCategory = galleryCategory;
        }
        public IActionResult Index()
        {

            VmGallery model = new VmGallery() {
            
             Gallery=_gallery.GetGallery(),
             GalleryCategory= _galleryCategory.GetGalleryCategory(),
            };
            return View(model);
        }
       
    }
}
