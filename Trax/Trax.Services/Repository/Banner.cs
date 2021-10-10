using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trax.Services.Repository.IRepository;

namespace Trax.Services.Repository
{
    public class Banner : IBanner
    {
        private readonly AppDbContext _context;

        public Banner(AppDbContext context)
        {
            _context = context;
        }
        public Models.Banner CreateBanner(Models.Banner model)
        {
            _context.Banner.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool DeleteBanner(int id)
        {
            Models.Banner banner = _context.Banner.Find(id);
            _context.Banner.Remove(banner);
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public List<Models.Banner> GetBanner()
        {
            return _context.Banner.ToList();
        }

        public Models.Banner GetBanner(int id)
        {
            return _context.Banner.Find(id);
        }

        public Models.Banner UpdateBanner(Models.Banner model)
        {
            _context.Banner.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
