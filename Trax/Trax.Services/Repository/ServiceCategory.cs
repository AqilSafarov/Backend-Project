using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trax.Services.Repository.IRepository;

namespace Trax.Services.Repository
{
    public class ServiceCategory : IServiceCategory
    {
        private readonly AppDbContext _context;

        public ServiceCategory(AppDbContext context)
        {
            _context = context;
        }
        public Models.ServiceCategory CreateServiceCategory(Models.ServiceCategory model)
        {
            _context.ServiceCategory.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool DeleteServiceCategory(int id)
        {
            Models.ServiceCategory serviceCategory = _context.ServiceCategory.Find(id);
            _context.ServiceCategory.Remove(serviceCategory);
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public List<Models.ServiceCategory> GetServiceCategory()
        {
            return _context.ServiceCategory.ToList();
        }

        public Models.ServiceCategory GetServiceCategory(int id)
        {
            return _context.ServiceCategory.Find(id);
        }

        public Models.ServiceCategory UpdateServiceCategory(Models.ServiceCategory model)
        {
            _context.ServiceCategory.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
