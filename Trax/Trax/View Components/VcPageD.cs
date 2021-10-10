using Trax.Models;
using Trax.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trax.ViewComponents
{
    public class VcPageD : ViewComponent
    {
        private readonly AppDbContext _context;

        public VcPageD(AppDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke(int pageid)
        {
            PageDetail model = _context.PageDetail.FirstOrDefault(p=>p.PageId==pageid);

            return View(model); 
        }
    }
}
