using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trax.Services.Repository.IRepository;

namespace Trax.Services.Repository
{
    public class ProcessType : IProcessType
    {
        private readonly AppDbContext _context;

        public ProcessType(AppDbContext context)
        {
            _context = context;
        }
        public Models.ProcessType CreateProcessType(Models.ProcessType model)
        {
            _context.ProcessType.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool DeleteProcessType(int id)
        {
            Models.ProcessType processType = _context.ProcessType.Find(id);
            _context.ProcessType.Remove(processType);
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public List<Models.ProcessType> GetProcessType()
        {
            return _context.ProcessType.ToList();
        }

        public Models.ProcessType GetProcessType(int id)
        {
            return _context.ProcessType.Find(id);
        }

        public Models.ProcessType UpdateProcessType(Models.ProcessType model)
        {
            _context.ProcessType.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
