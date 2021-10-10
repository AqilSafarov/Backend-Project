using System;
using System.Collections.Generic;
using System.Text;

namespace Trax.Services.Repository.IRepository
{
   public  interface IServiceCategory
    {
        List<Models.ServiceCategory> GetServiceCategory();
        Models.ServiceCategory GetServiceCategory(int id);
        Models.ServiceCategory CreateServiceCategory(Models.ServiceCategory model);
        Models.ServiceCategory UpdateServiceCategory(Models.ServiceCategory model);
        bool DeleteServiceCategory(int id);
    }
}
