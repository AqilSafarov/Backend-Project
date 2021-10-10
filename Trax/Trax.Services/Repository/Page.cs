using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trax.Services.Repository.IRepository;

namespace Trax.Services.Repository
{
    public class Page : IPage
    {
        private readonly AppDbContext _context;

        public Page(AppDbContext context)
        {
            _context = context;
        }
        public Models.Page CreatePage(Models.Page model)
        {
            _context.Page.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool DeletePage(int id)
        {
            Models.Page page = _context.Page.Find(id);
            _context.Page.Remove(page);
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public List<Models.Page> GetPage()
        {
            return _context.Page.ToList();
        }

        public Models.Page GetPage(int id)
        {
            return _context.Page.Find(id);
        }

        public Models.Page UpdatePage(Models.Page model)
        {
            _context.Page.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
