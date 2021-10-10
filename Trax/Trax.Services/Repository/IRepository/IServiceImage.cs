using System;
using System.Collections.Generic;
using System.Text;

namespace Trax.Services.Repository.IRepository
{
   public interface IServiceImage
    {
        List<Models.ServiceImage> GetServiceImage();
        Models.ServiceImage GetServiceImage(int id);
        Models.ServiceImage CreateServiceImage(Models.ServiceImage model);
        Models.ServiceImage UpdateServiceImage(Models.ServiceImage model);
        bool DeleteServiceImage(int id);
    }
}
