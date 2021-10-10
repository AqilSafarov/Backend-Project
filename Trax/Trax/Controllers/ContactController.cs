using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class ContactController : Controller
    {
        private readonly ISubscribe _subscribe;
        private readonly IContact _contact;
        private readonly AppDbContext _context;
        private readonly IMessage _message;
        private readonly ISetting _setting;
        private readonly ISocial _social;
        private readonly IPageDetail _pageDetail;

        public ContactController(ISubscribe subscribe,IContact contact,AppDbContext context,IMessage message,ISetting setting,ISocial social,IPageDetail pageDetail)
        {
            _subscribe = subscribe;
            _contact = contact;
            _context = context;
            _message = message;
            _setting = setting;
            _social = social;
            _pageDetail = pageDetail;
        }
        public IActionResult Index()
        {
            VmFooter model = new VmFooter() { 
                Contact=_contact.GetContact(),
                Setting= _setting.GetSetting(),
                Social=_social.GetSocials(),
                PageDetail= _pageDetail.GetPageDetail(),
            };



            return View(model); 
        }

        [HttpGet]
        public IActionResult Message(VmFooter model)
        {
            if (ModelState.IsValid)
            {
                model.Message.CreatedDate = DateTime.Now;
                _message.CreateMessage(model.Message);
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index","Service");
        }


    }

}

