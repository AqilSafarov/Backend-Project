using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trax.Services.Repository.IRepository;

namespace Trax.Services.Repository
{
    public class Gallery : IGallery
    {
        private readonly AppDbContext _context;

        public Gallery(AppDbContext context)
        {
            _context = context;
        }
        public Models.Gallery CreateGallery(Models.Gallery model)
        {
            _context.Gallery.Add(model);
            _context.SaveChanges();
            return model;

        }

        public bool DeleteGallery(int id)
        {
            Models.Gallery gallery = _context.Gallery.Find(id);
            _context.Gallery.Remove(gallery);
            if (_context.SaveChanges()>0)
            {
                return true;
            }
            return false;
        }

        public List<Models.Gallery> GetGallery()
        {
            return _context.Gallery.Include(g=>g.GalleryCategory).ThenInclude(c=>c.Gallery).ToList();
        }

        public Models.Gallery GetGallery(int? id)
        {
            return _context.Gallery.Include(c=>c.GalleryCategory).FirstOrDefault(c=>c.Id==id);
        }

        public Models.Gallery UpdateGallery(Models.Gallery model)
        {
            _context.Gallery.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
