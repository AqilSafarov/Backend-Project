using System;
using System.Collections.Generic;
using System.Text;

namespace Trax.Services.Repository.IRepository
{
    public interface IGallery
    {
        List<Models.Gallery> GetGallery();
        Models.Gallery GetGallery(int? id);
        Models.Gallery CreateGallery(Models.Gallery model);
        Models.Gallery UpdateGallery(Models.Gallery model);
        bool DeleteGallery(int id);
    }
}
