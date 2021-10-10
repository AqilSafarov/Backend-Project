using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trax.Services.Repository.IRepository;

namespace Trax.Services.Repository
{
    public class GalleryCategory : IGalleryCategory
    {
        private readonly AppDbContext _context;

        public GalleryCategory(AppDbContext context)
        {
            _context = context;
        }
        public Models.GalleryCategory CreateGalleryCategory(Models.GalleryCategory model)
        {
            _context.GalleryCategory.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool DeleteGalleryCategory(int id)
        {
            Models.GalleryCategory galleryCategory = _context.GalleryCategory.Find(id);
            _context.GalleryCategory.Remove(galleryCategory);
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public List<Models.GalleryCategory> GetGalleryCategory()
        {
            return _context.GalleryCategory.ToList();
        }

        public Models.GalleryCategory GetGalleryCategory(int id)
        {
            return _context.GalleryCategory.Find(id);
        }

        public Models.GalleryCategory GetGalleryCategorySing()
        {
            return _context.GalleryCategory.FirstOrDefault();
        }

        public Models.GalleryCategory UpdateGalleryCategory(Models.GalleryCategory model)
        {
            _context.GalleryCategory.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
