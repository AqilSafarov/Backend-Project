using Trax.Models;
using Trax.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trax.Services.Repository.IRepository;
using Trax.ViewModels;

namespace Trax.ViewComponents
{
    public class VcPartner : ViewComponent
    {
        private readonly AppDbContext _context;
        private readonly IPartner _partner;

        public VcPartner(AppDbContext context,IPartner partner)
        {
            _context = context;
            _partner = partner;
        }
        public IViewComponentResult Invoke()
        {
            VmAbout model = new VmAbout()
            {
                Partner = _partner.GetPartner()

            };

            return View(model);
        }
    }
}
