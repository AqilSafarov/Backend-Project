using System;
using System.Collections.Generic;
using System.Text;

namespace Trax.Services.Repository.IRepository
{
    public interface IPage
    {
        List<Models.Page> GetPage();
        Models.Page GetPage(int id);
        Models.Page CreatePage(Models.Page model);
        Models.Page UpdatePage(Models.Page model);
        bool DeletePage(int id);
    }
}
