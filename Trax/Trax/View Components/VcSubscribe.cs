using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trax.Models;
using Trax.Services.Repository.IRepository;

namespace Trax.View_Components
{
    public class VcSubscribe: ViewComponent
    {
        private readonly ISubscribe _subscribe;

        public VcSubscribe(ISubscribe subscribe)
        {
            _subscribe = subscribe;

        }
        public IViewComponentResult Invoke()
        {
            Subscribe subscribe = new Subscribe();
            return View(subscribe);
        }

        //[HttpPost]
        //public IViewComponentResult Invoke(Subscribe model)
        //{
        //    Subscribe subscribe = new Subscribe();
        //    return View(subscribe);
        //}
        //public IActionResult Subscribe(Subscribe model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (!_subscribe.GetSubscribe(model.Email))
        //        {
        //            _subscribe.CreateSubscribe(model);

        //        }
        //        ModelState.AddModelError("", "Qaqa eyni maildi");

        //    }

        //    return RedirectToAction("Index", "About");
        //}

    }
}
