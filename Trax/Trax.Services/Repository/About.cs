using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trax.Services.Repository.IRepository;

namespace Trax.Services.Repository
{
    public class About : IAbout
    {
        private readonly AppDbContext _context;

        public About(AppDbContext context)
        {
            _context = context;
        }
        public Models.About CreateAbout(Models.About model)
        {
            _context.About.Add(model);
            _context.SaveChanges();
            return (model);

        }

        public bool DeleteAbout(int id)
        {
            Models.About about = _context.About.Find(id);
            _context.About.Remove(about);
            if (_context.SaveChanges() > 0)
            {
                return true;
            }

            return false;
        }

        public List<Models.About> GetAbout()
        {
            return _context.About.ToList();
        }

        public Models.About GetAboutParm(int? id)
        {
            return _context.About.Find(id);
        }

        public Models.About UpdateAbout(Models.About model)
        {
            _context.About.Update(model);
            _context.SaveChanges();
            return model;
        }
        public Models.About FindAbout(int? aboutId)
        {
            return _context.About.Find(aboutId);
        }
    }
}
