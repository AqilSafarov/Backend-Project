using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trax.Services.Repository.IRepository;

namespace Trax.Services.Repository
{
    public class Service : IService
    {
        private readonly AppDbContext _context;

        public Service(AppDbContext context)
        {
            _context = context;
        }
        public Models.Service CreateService(Models.Service model)
        {
            _context.Service.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool DeleteService(int id)
        {
            Models.Service service = _context.Service.Find(id);
            _context.Service.Remove(service);
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public List<Models.Service> GetService()
        {
            return _context.Service.Include(s=>s.ServiceCategory).Include(i=>i.ServiceImages).Include(a=>a.Accordions).ToList();
        }

        public Models.Service GetService(int? id)
        {
            return _context.Service.Include(c=>c.ServiceCategory).Include(i => i.ServiceImages).FirstOrDefault(p => p.Id == id); ;
        }

        public Models.Service UpdateService(Models.Service model)
        {
            _context.Service.Update(model);
            _context.SaveChanges();
            return model;
        }
        public Models.Service FindService(int? serviceId)
        {
            return _context.Service.Find(serviceId);
        }


    }
}
