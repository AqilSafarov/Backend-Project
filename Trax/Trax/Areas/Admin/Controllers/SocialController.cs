using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trax.Services.Repository.IRepository;

namespace Trax.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = "Admin,Moderator")]
    public class SocialController : Controller
    {
        private readonly ISocial _social;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SocialController(ISocial social, IWebHostEnvironment webHostEnvironment)
        {
            _social = social;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index(int page = 1)
        {
            ViewBag.Active = "Social";
            List<Models.Social> socials1 = _social.GetSocials();
            decimal dataPage = 3;
            decimal pageCount = Math.Ceiling(socials1.Count / dataPage);

            List<Models.Social> socials2 = socials1.OrderByDescending(o => o.Id).Skip(Convert.ToInt32((page - 1) * dataPage)).Take((int)dataPage).ToList();
            ViewBag.CurrentPage = page;
            ViewBag.PageCount = pageCount;
            ViewBag.DataPage = dataPage;
            ViewBag.DataCount = socials1.Count;
            return View(socials2);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Models.Social model)
        {
            if (ModelState.IsValid)
            {
                _social.CreateSocial(model);

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Update(int socialId)
        {
            if (socialId == null && socialId <= 0)
            {
                return NotFound();
            }
            Models.Social social = _social.GetSocial(socialId);
            return View(social);
        }

        [HttpPost]
        public IActionResult Update(Models.Social model)
        {
            if (ModelState.IsValid)
            {
                _social.UpdateSocial(model);

                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Duzgun duzelt!");
            return View();

        }

        public IActionResult Delete(int socialId)
        {
            _social.DeleteSocial(socialId);
            return RedirectToAction("Index");
        }
    }
}
