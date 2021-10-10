using System;
using System.Collections.Generic;
using System.Text;

namespace Trax.Services.Repository.IRepository
{
    public interface ISocial
    {
        List<Models.Social> GetSocials();
        Models.Social GetSocial(int id);
        Models.Social GetSocialSing();
        Models.Social CreateSocial(Models.Social model);
        Models.Social UpdateSocial(Models.Social model);
        bool DeleteSocial(int id);
    }
}
