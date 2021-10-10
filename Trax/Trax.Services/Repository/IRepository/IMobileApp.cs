using System;
using System.Collections.Generic;
using System.Text;

namespace Trax.Services.Repository.IRepository
{
   public interface IMobileApp
    {
        List<Models.MobileApp> GetMobileApp();
        Models.MobileApp GetMobileApp(int id);
        Models.MobileApp CreateMobileApp(Models.MobileApp model);
        Models.MobileApp UpdateMobileApp(Models.MobileApp model);
        bool DeleteMobileApp(int id);
    }
}
