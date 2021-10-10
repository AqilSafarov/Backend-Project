using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trax.Services.Repository.IRepository;

namespace Trax.Services.Repository
{
    public class Expert : IExpert
    {
        private readonly AppDbContext _context;

        public Expert(AppDbContext context)
        {
            _context = context;
        }
        public Models.Expert CreateExpert(Models.Expert model)
        {
            _context.Expert.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool DeleteExpert(int id)
        {
            Models.Expert expert = _context.Expert.Find(id);
            _context.Expert.Remove(expert);
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

       

        public Models.Expert GetExpert()
        {
            return _context.Expert.FirstOrDefault();
        }

        public List<Models.Expert> GetExperts()
        {
            return _context.Expert.ToList();
        }

        public Models.Expert UpdateExpert(Models.Expert model)
        {
            _context.Expert.Update(model);
            _context.SaveChanges();
            return model;
        }
       

        public Models.Expert FindExpert(int? expertId)
        {
            return _context.Expert.Find(expertId);
        }
    }
}
