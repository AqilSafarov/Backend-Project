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
    public class AboutController : Controller
    {
        private readonly ISubscribe _subscribe;
        private readonly AppDbContext _context;
        private readonly ISkill _skill;

        public AboutController(ISubscribe subscribe,AppDbContext context,ISkill skill)
        {
            _subscribe = subscribe;
            _context = context;
            _skill = skill;
        }
        public IActionResult Index()
        {
            VmAbout model = new VmAbout();
            model.About = _context.About.FirstOrDefault();
            model.Partner = _context.Partner.ToList();
            model.Skill = _context.Skill.ToList();
            return View(model);
        }
       

    }
}
