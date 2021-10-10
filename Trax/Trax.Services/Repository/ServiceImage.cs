using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trax.Services.Repository.IRepository;

namespace Trax.Services.Repository
{
    public class ServiceImage : IServiceImage
    {
        private readonly AppDbContext _context;

        public ServiceImage(AppDbContext context)
        {
            _context = context;
        }
        public Models.ServiceImage CreateServiceImage(Models.ServiceImage model)
        {
            _context.ServiceImage.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool DeleteServiceImage(int id)
        {
            Models.ServiceImage ServiceImage = _context.ServiceImage.Find(id);
            _context.ServiceImage.Remove(ServiceImage);
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public List<Models.ServiceImage> GetServiceImage()
        {
            return _context.ServiceImage.ToList();
        }

        public Models.ServiceImage GetServiceImage(int id)
        {
            return _context.ServiceImage.Find(id);
        }

        public Models.ServiceImage UpdateServiceImage(Models.ServiceImage model)
        {
            _context.ServiceImage.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
