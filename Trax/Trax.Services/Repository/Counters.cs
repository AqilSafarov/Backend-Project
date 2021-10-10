using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trax.Services.Repository.IRepository;

namespace Trax.Services.Repository
{
    public class Counters : ICounters
    {
        private readonly AppDbContext _context;

        public Counters(AppDbContext context)
        {
            _context = context;
        }
        public Models.Counters CreateCounters(Models.Counters model)
        {
            _context.Counters.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool DeleteCounters(int id)
        {
            Models.Counters counters = _context.Counters.Find(id);
            _context.Counters.Remove(counters);
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public List<Models.Counters> GetCounters()
        {

            return _context.Counters.ToList();
        }

        public Models.Counters GetCounters(int? id)
        {
            return _context.Counters.Find(id);
        }

        public Models.Counters UpdateCounters(Models.Counters model)
        {
            _context.Counters.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
