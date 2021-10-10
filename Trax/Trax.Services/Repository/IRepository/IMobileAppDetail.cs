using System;
using System.Collections.Generic;
using System.Text;

namespace Trax.Services.Repository.IRepository
{
    public interface IMobileAppDetail
    {
        List<Models.MobileAppDetail> GetMobileAppDetail();
        Models.MobileAppDetail GetMobileAppDetail(int id);
        Models.MobileAppDetail CreateMobileAppDetail(Models.MobileAppDetail model);
        Models.MobileAppDetail UpdateMobileAppDetail(Models.MobileAppDetail model);
        bool DeleteMobileAppDetail(int id);
    }
}
