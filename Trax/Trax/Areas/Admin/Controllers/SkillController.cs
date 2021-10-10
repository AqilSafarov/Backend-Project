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
    public class SkillController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ISkill _skill;

        public SkillController(ISkill skill, IWebHostEnvironment webHostEnvironment)
        {
            _skill = skill;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index(int page = 1)
        {
            ViewBag.Active = "Skill";
            List<Models.Skill> skill1 = _skill.GetSkill();
            decimal dataPage = 3;
            decimal pageCount = Math.Ceiling(skill1.Count / dataPage);

            List<Models.Skill> skill2 = skill1.OrderByDescending(o => o.Id).Skip(Convert.ToInt32((page - 1) * dataPage)).Take((int)dataPage).ToList();
            ViewBag.CurrentPage = page;
            ViewBag.PageCount = pageCount;
            ViewBag.DataPage = dataPage;
            ViewBag.DataCount = skill1.Count;
            return View(skill2);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Models.Skill model)
        {
            if (ModelState.IsValid)
            {
                _skill.CreateSkill(model);

                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult Update(int skillId)
        {
            if (skillId == null && skillId <= 0)
            {
                return NotFound();
            }
            Models.Skill skill = _skill.GetSkill(skillId);
            return View(skill);
        }

        [HttpPost]
        public IActionResult Update(Models.Skill model)
        {
            if (ModelState.IsValid)
            {
                _skill.UpdateSkill(model);

                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Duzgun duzelt!");
            return View();

        }
        public IActionResult Delete(int skillId)
        {
            _skill.DeleteSkill(skillId);

            return RedirectToAction("Index");
        }

    }
}
