using System;
using System.Collections.Generic;
using System.Text;

namespace Trax.Services.Repository.IRepository
{
    public interface IGalleryCategory
    {
        List<Models.GalleryCategory> GetGalleryCategory();
        Models.GalleryCategory GetGalleryCategorySing();
        Models.GalleryCategory GetGalleryCategory(int id);
        Models.GalleryCategory CreateGalleryCategory(Models.GalleryCategory model);
        Models.GalleryCategory UpdateGalleryCategory(Models.GalleryCategory model);
        bool DeleteGalleryCategory(int id);
    }
}
