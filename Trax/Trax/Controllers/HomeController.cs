using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Trax.Models;
using Trax.Services;
using Trax.Services.Repository.IRepository;
using Trax.ViewModels;

namespace Trax.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISubscribe _subscribe;
        private readonly AppDbContext _context;

        public HomeController(ISubscribe subscribe,AppDbContext context)
        {
            _subscribe = subscribe;
            _context = context;
        }

        public IActionResult Index()
        {
            VmHome model = new VmHome();
            model.Testimonial = _context.Testimonial.ToList();
            model.Setting = _context.Setting.FirstOrDefault();
            model.MobileApp = _context.MobileApp.FirstOrDefault();
            model.MobileAppDetail = _context.MobileAppDetail.ToList();
            model.HomeOne = _context.HomeOne.FirstOrDefault();
            model.Testimonial = _context.Testimonial.ToList();
            model.Slider = _context.Slider.ToList();
            //model.Partner = _context.Partner.ToList();

            return View(model);
        }
        public IActionResult Subscribe(Subscribe model)
        {
            if (ModelState.IsValid)
            {
                if (!_subscribe.GetSubscribe(model.Email))
                {
                    model.CreatedDate = DateTime.Now;
                    _subscribe.CreateSubscribe(model);
                }
                ModelState.AddModelError("", "Qaqa eyni maildi");

            }

            return RedirectToAction("Index", "About");
        }

    }
}
