using System;
using System.Collections.Generic;
using System.Text;
using Trax.Models;

namespace Trax.Services.Repository.IRepository
{
    public interface IBanner
    {
        List<Models.Banner> GetBanner();
        Models.Banner GetBanner(int id);
        Models.Banner CreateBanner(Models.Banner model);
        Models.Banner UpdateBanner(Models.Banner model);
        bool DeleteBanner(int id);
    }
}
