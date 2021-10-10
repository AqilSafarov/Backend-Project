using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trax.Services.Repository.IRepository;

namespace Trax.Services.Repository
{
    public class HomeOne : IHomeOne
    {
        private readonly AppDbContext _context;

        public HomeOne(AppDbContext context)
        {
            _context = context;
        }
        public Models.HomeOne CreateHomeOne(Models.HomeOne model)
        {
            _context.HomeOne.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool DeleteHomeOne(int? id)
        {
            Models.HomeOne homeOne = _context.HomeOne.Find(id);
            _context.HomeOne.Remove(homeOne);
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public List<Models.HomeOne> GetHomeOne()
        {
            return _context.HomeOne.ToList();
        }

        public Models.HomeOne GetHomeOne(int? id)
        {
            return _context.HomeOne.Find(id);
        }

        public Models.HomeOne UpdateHomeOne(Models.HomeOne model)
        {
            _context.HomeOne.Update(model);
            _context.SaveChanges();
            return model;
        }
        public Models.HomeOne FindHomeOne(int? homeoneId)
        {
            return _context.HomeOne.Find(homeoneId);
        }

       
    }
}
