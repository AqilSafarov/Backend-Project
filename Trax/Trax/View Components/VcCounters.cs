using Trax.Models;
using Trax.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trax.Services.Repository.IRepository;

namespace Trax.ViewComponents
{
    public class VcCounters : ViewComponent
    {
        private readonly ICounters _counters;
        private readonly AppDbContext _context;

        public VcCounters(ICounters counters,AppDbContext context)
        {
            _counters = counters;
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            Counters counter = _context.Counters.FirstOrDefault();

            return View(counter);
        }
    }
}
