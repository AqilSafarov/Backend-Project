using System;
using System.Collections.Generic;
using System.Text;

namespace Trax.Services.Repository.IRepository
{
   public interface IAbout
    {
        List<Models.About> GetAbout();
        Models.About GetAboutParm(int? id);
        Models.About CreateAbout(Models.About model);
        Models.About UpdateAbout(Models.About model);
        bool DeleteAbout(int id);
        Models.About FindAbout(int? aboutId);



    }
}
