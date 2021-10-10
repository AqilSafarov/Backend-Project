using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trax.Services.Repository.IRepository;

namespace Trax.Services.Repository
{
    public class Process : IProcess
    {
        private readonly AppDbContext _context;

        public Process(AppDbContext context)
        {
            _context = context;
        }
        public Models.Process CreateProcess(Models.Process model)
        {
            _context.Process.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool DeleteProcess(int? id)
        {
            Models.Process Process = _context.Process.Find(id);
            _context.Process.Remove(Process);
            if (_context.SaveChanges() > 0)
                return true;
            return false;
        }

        public Models.Process GetProcessParam(int? id)
        {
            return _context.Process.Find(id);
        }

        public List<Models.Process> GetProcess()
        {
            return _context.Process.ToList();
        }

        public Models.Process GetProcessSingle()
        {
            return _context.Process.FirstOrDefault();
        }


        public Models.Process UpdateProcess(Models.Process model)
        {
            _context.Process.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
