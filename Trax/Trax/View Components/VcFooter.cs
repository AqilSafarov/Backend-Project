using Trax.Services.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trax.ViewModels;
using Trax.Models;

namespace Trax.ViewComponents
{
    public class VcFooter:ViewComponent
    {
        private readonly ISocial _social;
        private readonly ISetting _setting;
        private readonly ISubscribe _subscribe;
        private readonly IContact _contact;
        private readonly IPageDetail _pageDetail;

        public VcFooter(ISocial social, ISetting setting, ISubscribe subscribe,IContact contact, IPageDetail pageDetail)
        {
            _social = social;
            _setting = setting;
            _subscribe = subscribe;
            _contact = contact;
            _pageDetail = pageDetail;
        }

        public IViewComponentResult Invoke()
        {
            VmFooter model = new VmFooter()
            {
                Setting = _setting.GetSetting(),
                Social = _social.GetSocials(),
                Contact = _contact.GetContact(),
                PageDetail = _pageDetail.GetPageDetail()

            };

            return View(model);
        }

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
