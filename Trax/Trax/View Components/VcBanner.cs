using Trax.Models;
using Trax.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trax.ViewComponents
{
    public class VcBanner : ViewComponent
    {
        private readonly AppDbContext _context;

        public VcBanner(AppDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke(int pageid)
        {
            Banner model = _context.Banner.FirstOrDefault(p=>p.PageId==pageid);

            return View(model); 
        }
    }
}
