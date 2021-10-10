using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trax.Services.Repository.IRepository;

namespace Trax.Services.Repository
{
    public class Accordion : IAccordion
    {
        private readonly AppDbContext _context;

        public Accordion(AppDbContext context)
        {
            _context = context;
        }
        public Models.Accordion CreateAccrodion(Models.Accordion model)
        {
            _context.Accordion.Add(model);
            _context.SaveChanges();
            return model;

        }

        public bool DeleteAccordion(int id)
        {
            Models.Accordion accordion = _context.Accordion.Find(id);
            _context.Accordion.Remove(accordion);
            if (_context.SaveChanges()>0)
            {
                return true;
            }
            return false;
        }

        public List<Models.Accordion> GetAccordion()
        {

            return _context.Accordion.ToList();
        }

        public Models.Accordion GetAccordion(int id)
        {
            return _context.Accordion.Find(id);
        }

        public Models.Accordion UpdateAccrodion(Models.Accordion model)
        {
            _context.Accordion.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
