using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trax.Services.Repository.IRepository;

namespace Trax.Services.Repository
{
    public class PageDetail : IPageDetail
    {
        private readonly AppDbContext _context;

        public PageDetail(AppDbContext context)
        {
            _context = context;
        }
        public Models.PageDetail CreatePageDetail(Models.PageDetail model)
        {
            _context.PageDetail.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool DeletePageDetail(int id)
        {

            Models.PageDetail pageDetail = _context.PageDetail.Find(id);
            _context.PageDetail.Remove(pageDetail);
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        

        public Models.PageDetail GetPageDetail()
        {
            return _context.PageDetail.FirstOrDefault();
        }

        public Models.PageDetail UpdatePageDetail(Models.PageDetail model)
        {
            _context.PageDetail.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
